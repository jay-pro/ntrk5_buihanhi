using ecommerceweb.SharedModel;

namespace ecommerceweb.Website.Models
{
    public partial class MultiModels
    {
        public virtual ICollection<Category> Categories { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Order Order { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public ProductImage ProductImage { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public Rating Rating { get; set; }
        public virtual ICollection<TransactStatus> TransactStatuses { get; set; }
        public TransactStatus TransactStatus { get; set; }

    }
}
