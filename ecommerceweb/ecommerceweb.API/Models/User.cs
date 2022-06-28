namespace ecommerceweb.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

        /*public virtual List<Category> Categories { get; set; } = new List<Category>();
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();*/

    }
}
