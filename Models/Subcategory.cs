using System.ComponentModel.DataAnnotations;

namespace CliverApi.Models
{
    public class Subcategory
    {
        public Subcategory(string name)
        {
            Name=name;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
