using System.ComponentModel.DataAnnotations;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class CreatePostDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Category is required")]
        public int SubcategoryId { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
