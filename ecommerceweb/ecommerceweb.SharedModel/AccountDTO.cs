using ecommerceweb.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class AccountDTO
    {
        public AccountDTO()
        {
            Orders = new HashSet<OrderDTO>();
            Ratings = new HashSet<RatingDTO>();
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
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
    }
}
