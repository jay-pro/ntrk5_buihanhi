using ecommerceweb.SharedModel;

namespace ecommerceweb.Website.Models
{
    public class MVCModels
    {
        public List<Category> Categories { get; set; }
        public CategoryDTO Category { get; set; }

        //public List<Order> Orders { get; set; }
        //public OrderDTO Order { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }
        //public OrderDetailDTO OrderDetail { get; set; }

        public List<Product> Products { get; set; }
        public ProductDTO Product { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public ProductImageDTO ProductImage { get; set; }

        public List<Rating> Ratings { get; set; }
        public RatingDTO Rating { get; set; }

        //public List<TransactStatus> TransactStatuses { get; set; }
        //public TransactStatusDTO TransactStatus { get; set; }

    }
}
