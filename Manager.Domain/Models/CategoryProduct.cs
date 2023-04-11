using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class CategoryProduct
    {
        public int CategoryProductId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
