﻿namespace Application.DTOS.Product
{
    public class DetailInfoAboutProductDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public decimal Price { get; init; }

        public bool IsDiscount { get; init; }

        public string CategoryName { get; init; } = string.Empty;
        
        public string SubCategoryName { get; init; } = string.Empty;

        public decimal PriceWithDiscount { get; init; }
    }
}
