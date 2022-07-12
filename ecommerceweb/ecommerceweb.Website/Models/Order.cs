namespace ecommerceweb.Website.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Guid TransactStatusId { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public int TotalMoney { get; set; }
        public int? PaymentId { get; set; }
        public string? Note { get; set; }
        public string? Address { get; set; }
        public Guid? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual TransactStatus TransactStatus { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
