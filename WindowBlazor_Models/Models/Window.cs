using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models.Models
{
    public class Window
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubelements { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}
