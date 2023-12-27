using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBlazor_Models
{
    public class OrderHeaderDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        
        [Required]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
