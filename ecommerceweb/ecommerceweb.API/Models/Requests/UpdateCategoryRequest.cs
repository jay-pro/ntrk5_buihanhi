namespace ecommerceweb.API.Models
{
    public class UpdateCategoryRequest
    {
        public UpdateCategoryRequest()
        {
            Products = new HashSet<Product>();
        }
        //public int CategoryId { get; set; }//
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
