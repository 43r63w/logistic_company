

using Application.DTOS;
using Application.DTOS.Category;



namespace Application.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoriByIdAsync(int id);
        Task<GeneralResponseDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<GeneralResponseDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        Task<GeneralResponseDTO> DeleteCategoryAsync(int id);
    }


}
