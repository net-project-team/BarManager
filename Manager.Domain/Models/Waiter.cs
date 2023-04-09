using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class Waiter
    {
        public int WaiterId { get; set; }
        public string? WaiterName { get; set; }
        public string? Phone { get; set; }
        public required string Password { get; set; }   
      
    }
}
