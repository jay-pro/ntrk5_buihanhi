using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class ProductDTO
    {
        public ProductDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
            Ratings = new HashSet<RatingDTO>();
            ProductImages = new HashSet<ProductImageDTO>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string? Tags { get; set; }
        public int? UnitsInStock { get; set; }
        public virtual CategoryDTO? Category { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
        public ICollection<RatingDTO> Ratings { get; set; }
        public ICollection<ProductImageDTO> ProductImages { get; set; }

    }
}
