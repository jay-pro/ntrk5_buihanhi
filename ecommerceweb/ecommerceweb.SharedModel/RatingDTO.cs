using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class RatingDTO
    {
        public int RatingId { get; set; }
        public string Content { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public virtual AccountDTO? Account { get; set; }
        public virtual ProductDTO? Product { get; set; }
    }
}
