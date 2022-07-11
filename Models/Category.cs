using System.ComponentModel.DataAnnotations;

namespace CliverApi.Models
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
