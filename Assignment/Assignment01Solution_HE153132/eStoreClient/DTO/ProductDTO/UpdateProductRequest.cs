﻿using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.ProductDTO
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int? UnitsInStock { get; set; }
    }
}