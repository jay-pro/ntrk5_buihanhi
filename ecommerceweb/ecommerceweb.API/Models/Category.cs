namespace ecommerceweb.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        /*public virtual User User { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();*/
    }
}
