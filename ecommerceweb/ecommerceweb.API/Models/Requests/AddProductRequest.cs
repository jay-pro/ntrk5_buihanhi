using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.API.Models
{
    public class AddProductRequest
    {

        //public int ProductId { get; set; }//
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
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
