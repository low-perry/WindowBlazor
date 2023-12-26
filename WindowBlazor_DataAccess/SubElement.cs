using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_DataAccess
{
    public class SubElement
    {
        public int Id { get; set; }
        public string Element { get; set; }
        public string Type { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        
        public int WindowId { get; set; }
        [ForeignKey("WindowId")]
        public Window Window { get; set; }
    }
}
