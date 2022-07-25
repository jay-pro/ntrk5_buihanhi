using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.API.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string Content { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }

    }
}
