using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public List<Window> Windows { get; set; }
    }
}
