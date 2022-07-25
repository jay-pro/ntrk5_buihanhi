using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel
{
    public partial class ProductImageDTO
    {
        public int ProductImageId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
        /*public virtual Product Product { get; set; }*/
    }
}
