using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models
{
    public class WindowDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int QuantityOfWindows { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total Sub Elements must be greater than 0")]
        public int TotalSubElements { get; set; }
        public ICollection<SubElementDTO> SubElements { get; set; }
    }
}
