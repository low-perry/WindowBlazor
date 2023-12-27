using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [Required]
        public int WindowId { get; set; }
        public WindowDTO Window { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public string WindowName { get; set; }
    }
}
