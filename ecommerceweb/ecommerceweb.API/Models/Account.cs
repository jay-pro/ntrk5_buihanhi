using ecommerceweb.API.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.API.Models
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
        }

        public int AccountId { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public AccountRole Role { get; set; }
        /*[ForeignKey("Role")]
        public int? RoleId { get; set; }*/
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        /*public virtual Role? Role { get; set; }*/
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
