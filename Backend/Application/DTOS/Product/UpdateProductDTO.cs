namespace Application.DTOS.Product
{
    public class UpdateProductDTO
    {
        public string Name { get; init; } = string.Empty;

        public string QuantityPerUnit { get; set; } = string.Empty;

        public decimal Price { get; init; }

        public bool IsDiscount { get; init; }

        public string CategoryName { get; init; } = string.Empty;

        public string SubCategoryName { get; init; } = string.Empty;

        public decimal PriceWithDiscount { get; set; }
    }
}
