using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Blazor.Models
{
    public class TaskCreatingViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"\d\s?([0-1][0-9]|2[0-3])\s?[0-5][0-9]",
            ErrorMessage = "Incorrect time format.")]
        public string LeadTime { get; set; } = "0 00 00";
    }
}