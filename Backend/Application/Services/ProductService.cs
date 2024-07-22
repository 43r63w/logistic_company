using Application.Configuring.Exceptions;
using Application.Configuring.Validators;
using Application.DTOS;
using Application.DTOS.Product;
using Application.IServices;
using AutoMapper;
using Domain.DbSets;
using Infrastructure.IGenericRepository;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<ICollection<DetailInfoAboutProductDTO>> GetProductsAsync()
        {
            var list = await _unitOfWork.ProductRepository.GetAllAsync(includeOptions: "Category,SubCategory");
            var mapped = _mapper.Map<List<DetailInfoAboutProductDTO>>(list);
            return mapped;
        }
        public async Task<DetailInfoAboutProductDTO> GetProductByIdAsync(int id)
        {
            var getFromDb = await _unitOfWork.ProductRepository.GetAsync(i => i.Id == id, includeOptions: "Category,SubCategory");
            if (getFromDb == null)
            {
                throw new NotFoundException($"Product isn`n exists", $"Id:{id}");
            }

            var mapped = _mapper.Map<DetailInfoAboutProductDTO>(getFromDb);
            return mapped;
        }
        public async Task<GeneralResponseDTO> CreateProductAsync(CreateProductDTO productDto)
        {
            var validation = new ProductValidator(_unitOfWork);
            var result = await validation.ValidateAsync(productDto);


            var getCategory = await _unitOfWork.CategoryRepository
                .GetAsync(e => e.Name.ToLower() == productDto.CategoryName.ToLower());

            var getSubCategory = await _unitOfWork.SubCategoryRepository
                .GetAsync(e => e.SubCategoryName.ToLower() == productDto.SubCategoryName.ToLower());

            if (!result.IsValid)
            {
                throw new BadRequestException("Something went wrong", result.ToDictionary());
            }
            var mapped = _mapper.Map<Product>(productDto);


            mapped.CategoryId = getCategory.Id;
            mapped.SubCategoryId = getSubCategory.Id;

            await _unitOfWork.ProductRepository.CreateAsync(mapped);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{mapped.Name} successfully created"
            };

        }
        public async Task<GeneralResponseDTO> UpdateProductAsync(int id, UpdateProductDTO updateProductDto)
        {
            var getFromDb = await _unitOfWork.ProductRepository.GetAsync(e => e.Id == id);
            if (getFromDb == null)
            {
                throw new NotFoundException("Product", $"Id:{id}");
            }

            if (string.IsNullOrWhiteSpace(updateProductDto.CategoryName) || updateProductDto.CategoryName.Contains("string"))
                getFromDb.CategoryId = getFromDb.CategoryId;
            if (string.IsNullOrWhiteSpace(updateProductDto.SubCategoryName) || updateProductDto.SubCategoryName.Contains("string"))
                getFromDb.SubCategoryId = getFromDb.SubCategoryId;

            getFromDb.Name = updateProductDto.Name;
            getFromDb.Price = updateProductDto.Price;
            getFromDb.IsDiscount = updateProductDto.IsDiscount;
            getFromDb.QuantityPerUnit = updateProductDto.QuantityPerUnit;
            getFromDb.PriceWithDiscount = updateProductDto.PriceWithDiscount;

            await _unitOfWork.ProductRepository.UpdateAsync(getFromDb);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{updateProductDto.Name} successfully updated"
            };

        }
        public async Task<GeneralResponseDTO> DeleteProductAsync(int id)
        {
            var getFromDb = await _unitOfWork.ProductRepository.GetAsync(e => e.Id == id);
            if (getFromDb == null)
            {
                throw new NotFoundException("Product", $"Id:{id}");
            }

            await _unitOfWork.ProductRepository.DeleteAsync(getFromDb);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{getFromDb.Name} successfully deleted"
            };
        }
    }
}
