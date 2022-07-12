using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliverApi.Models
{
    public class Post : AuditEntity
    {
        public Post()
        {
            Tag = string.Empty;
            Subcategory= null!;
            Packages=  new HashSet<Package>() ;
            Tags = new List<string>();
        }

        public int Id { get; set; }
        [Required]
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public string Tag { get; set; }
        [NotMapped]
        public List<string> Tags { get; set; }
        public ICollection<Package> Packages { get; set; }

    }
}
