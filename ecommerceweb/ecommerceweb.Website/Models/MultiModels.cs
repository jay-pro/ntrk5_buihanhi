using ecommerceweb.SharedModel;

namespace ecommerceweb.Website.Models
{
    public partial class MultiModels
    {
        public virtual ICollection<CategoryDTO> Categories { get; set; }
        public CategoryDTO Category { get; set; }
        public virtual ICollection<OrderDTO> Orders { get; set; }
        public OrderDTO Order { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
        public OrderDetailDTO OrderDetail { get; set; }
        public virtual ICollection<ProductDTO> Products { get; set; }
        public ProductDTO Product { get; set; }
        public virtual ICollection<ProductImageDTO> ProductImages { get; set; }
        public ProductImageDTO ProductImage { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public RatingDTO Rating { get; set; }
        public virtual ICollection<TransactStatusDTO> TransactStatuses { get; set; }
        public TransactStatusDTO TransactStatus { get; set; }

    }
}
