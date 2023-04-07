using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductDescription { get; set;}
        public string? ProductPicture { get; set; } 
    }
}
