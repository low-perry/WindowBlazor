using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models
{
    public class SubElementDTO
    {
        public int Id { get; set; }
        [Required]
        public string Element { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Height should be greater than or equal to 1")]
        public int Height { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Width should be greater than or equal to 1")]
        public int Width { get; set; }
        [Required]
        public int WindowId { get; set; }
        
    }
}
