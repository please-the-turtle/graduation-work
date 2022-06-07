using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Blazor.Models
{
    public class ProjectAddingViewModel
    {
        public const int MaxNameLength = 100;
        public const int MaxDescriptionLength = 500;

        [Required]
        [StringLength(MaxNameLength, ErrorMessage = $"Name length can't be more than 100.")]
        public string Name { get; set; } = null!;

        [StringLength(MaxDescriptionLength, ErrorMessage = $"Description length can't be more than 500.")]
        public string Description { get; set; } = null!;
    }
}
