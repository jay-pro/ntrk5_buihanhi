﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.API.Models
{
    public class UpdateProductRequest
    {

        //public int ProductId { get; set; }//
        public string ProductName { get; set; } = null!;
        public string? ShortDesc { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("Category")]
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string? Images { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string? Tags { get; set; }
        public int? UnitsInStock { get; set; }
        public virtual Category? Category { get; set; }

    }
}
