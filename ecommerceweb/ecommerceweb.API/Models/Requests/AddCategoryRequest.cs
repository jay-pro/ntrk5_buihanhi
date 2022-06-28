namespace ecommerceweb.API.Models
{
    public class AddCategoryRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
