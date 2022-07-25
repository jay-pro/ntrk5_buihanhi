using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class OrderDTO
    {
        public OrderDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
        }

        public int OrderId { get; set; }
        [ForeignKey("Account")]
        public int? AccountId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        [ForeignKey("TransactStatus")]
        public int TransactStatusId { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public int TotalMoney { get; set; }
        public int? PaymentId { get; set; }
        public string? Note { get; set; }
        public string? Address { get; set; }
        public virtual AccountDTO? Account { get; set; }
        public virtual TransactStatusDTO TransactStatus { get; set; } = null!;
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
