using Application.Configuring.Exceptions;
using Application.Configuring.Validators;
using Application.DTOS;
using Application.DTOS.Category;
using Application.IServices;
using AutoMapper;
using Domain.DbSets;
using Infrastructure.IGenericRepository;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GeneralResponseDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var validations = new CategoryValidator(_unitOfWork);
            var result = await validations.ValidateAsync(categoryDTO);

            if (!result.IsValid)
            {
                throw new BadRequestException("Error with model", result.ToDictionary());
            }

            var newCategory = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
            };

            await _unitOfWork.CategoryRepository.CreateAsync(newCategory);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO { IsSucceded = true, Message = $"{categoryDTO.Name} succsefully created!" };
        }

        public Task<GeneralResponseDTO> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> GetCategoriByIdAsync(int id)
        {
            var categoryFromDb = await _unitOfWork.CategoryRepository.GetAsync(i => i.Id == id);

            if (categoryFromDb == null)
            {
                throw new NotFoundException("Category", $"with {id}:id");
            }
            var mapped = _mapper.Map<CategoryDTO>(categoryFromDb);

            return mapped;

        }

        public async Task<ICollection<CategoryDTO>> GetCategoriesAsync()
        {
            var getList = await _unitOfWork.CategoryRepository.GetAllAsync();
            var result = _mapper.Map<List<CategoryDTO>>(getList);
            return result;
        }

        public async Task<GeneralResponseDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var get = await _unitOfWork.CategoryRepository.GetAsync(i => i.Id == id);
  
            var validatorRules = new CategoryValidator(_unitOfWork);
            var result = await validatorRules.ValidateAsync(categoryDTO);

            if (!result.IsValid)
            {
                throw new BadRequestException("Something wrong", result.ToDictionary());
            }

            get.Name = categoryDTO.Name;
            get.Description = categoryDTO.Description;
            await _unitOfWork.CategoryRepository.UpdateAsync(get);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO { IsSucceded = true, Message = $"{get.Name} succsesfully updated!" };
        }



    }
}
