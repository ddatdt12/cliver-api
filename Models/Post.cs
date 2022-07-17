using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Kensa.Common.Enum;

namespace CliverApi.Models
{
    [Table("Post")]
    public class Post : AuditEntity
    {
        public Post()
        {
            Status = PostStatus.Draft;
            Tags = String.Empty;
            Images = String.Empty;
            Subcategory = null!;
            UserId = null!;
            BasicPackage = null!;
            HasOfferPackages = false;
        }

        public int Id { get; set; }
        [MinLength(30)]
        public string Description { get; set; } = string.Empty;
        public PostStatus Status { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public string Tags { get; set; }
        public string Images { get; set; }
        public string? Video { get; set; }
        public string? Document { get; set; }
        public bool HasOfferPackages { get; set; }
        public Package? BasicPackage { get; set; }
        public Package? StandardPackage { get; set; }
        public Package? PremiumPackage { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
