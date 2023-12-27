using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_DataAccess
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }

        [Required]
        public int WindowtId { get; set; }
        [ForeignKey("windowId")]
        [NotMapped]
        public virtual Window Window { get; set; }

        [Required]
        public int Count { get; set; }
        [Required]
        
        public string WindowName { get; set; }
    }
}
