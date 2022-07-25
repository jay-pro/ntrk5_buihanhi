using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerceweb.Website.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public int? OrderNumber { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Price { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
