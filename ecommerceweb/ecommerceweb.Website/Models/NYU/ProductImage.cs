using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.Website.Models
{
    public partial class ProductImage
    {
        public int ProductImageId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public virtual Product Product { get; set; }
    }
}
