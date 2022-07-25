using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
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
        public virtual Account? Account { get; set; }
        public virtual TransactStatus TransactStatus { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
