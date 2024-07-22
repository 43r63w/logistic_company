using Application.DTOS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.Category
{
    public class GetProductsInCategoryByIdDTO
    {
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<DetailInfoAboutProductDTO> ProductsInfo { get; init; } = new List<DetailInfoAboutProductDTO>();

    }
}
