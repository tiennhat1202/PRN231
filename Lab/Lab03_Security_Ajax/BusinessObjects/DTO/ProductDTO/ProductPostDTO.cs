﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.ProductDTO
{
    public class ProductPostDTO
    {
        public int ProductId { get; set; }       
        public string ProductName { get; set; }       
        public int CategoryId { get; set; }       
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
    }
}
