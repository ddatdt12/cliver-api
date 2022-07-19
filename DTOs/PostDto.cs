using CliverApi.Models;
using System.ComponentModel;
using static Kensa.Common.Enum;

namespace CliverApi.DTOs
{
    public class PostDto : AuditEntity
    {
        public PostDto()
        {
            Subcategory = null!;
            Status = PostStatus.Draft;
            HasOfferPackages = false;
            BasicPackage = null!;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = null!;
        public PostStatus Status { get; set; }
        public UserDto User { get; set; } = null!;
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; } = null!;
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> Images { get; set; } = new List<string>();
        public string? Video { get; set; }
        public string? Document { get; set; }

        public bool HasOfferPackages { get; set; }
        
        public int BasicPackageId { get; set; }
        public Package BasicPackage { get; set; }
        
        public int? StandardPackageId { get; set; }
        public Package? StandardPackage { get; set; }
        
        public int? PremiumPackageId { get; set; }
        public Package? PremiumPackage { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

}
