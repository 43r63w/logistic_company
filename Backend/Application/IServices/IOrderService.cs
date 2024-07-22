using Application.DTOS;
using Application.DTOS.Order;

namespace Application.IServices
{
    public interface IOrderService
    {
       // Task<ICollection<>> GetCategoriesAsync();
       // Task<CategoryDTO> GetCategoriByIdAsync(int id);
        Task<GeneralResponseDTO> CreateCategoryAsync(CreateOrderDTO createOrderDto);
        
       // Task<GeneralResponseDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
      //  Task<GeneralResponseDTO> DeleteCategoryAsync(int id);
    }
}
