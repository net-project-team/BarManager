using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<int>? ProductId { get; set; }
        public int WaiterId { get; set; }
        public int OrderTable { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        
    }
}
