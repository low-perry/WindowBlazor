using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace WindowBlazor_Client.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Count = 1;
        }
        //Counter for the number of Windows
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Count should be greater than or equal to 1")]
        public int Count { get; set; }
    }
}
