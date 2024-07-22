using Application.DTOS;
using Application.DTOS.Product;
using Domain.DbSets;

namespace Application.IServices
{
    public interface IProductService
    {
        Task<ICollection<DetailInfoAboutProductDTO>> GetProductsAsync();
        Task<DetailInfoAboutProductDTO> GetProductByIdAsync(int id);
        Task<GeneralResponseDTO> CreateProductAsync(CreateProductDTO productDto);
        Task<GeneralResponseDTO> UpdateProductAsync(int id, UpdateProductDTO productDto);
        Task<GeneralResponseDTO> DeleteProductAsync(int id);
    }
}
