namespace ecommerceweb.API.Models
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Ratings { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SoldsNumb { get; set; }
        public int WarehousesNumb { get; set; }
    }
}
