using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public class ProductModel
    {
        public string Id { get; set; }//Guid
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ratings { get; set; }
        //[ValidateNever]
        public decimal Price { get; set; }
        [ValidateNever]
        public string Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SoldsNumb { get; set; }
        //[ValidateNever]
        public int WarehousesNumb { get; set; }
        //[ValidateNever]
        public string CategoryId { get; set; }
        [ValidateNever]
        public CategoryModel Category { get; set; }
    }
}
