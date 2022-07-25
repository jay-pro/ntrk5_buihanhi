using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class TransactStatusDTO
    {
        public TransactStatusDTO()
        {
            Orders = new HashSet<OrderDTO>();
        }

        public int TransactStatusId { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; }
    }
}
