using static Kensa.Common.Enum;

namespace CliverApi.DTOs
{
    public class UpdatePostDto
    {
        public UpdatePostDto()
        {
        }
        public string? Description { get; set; }
        public int? SubcategoryId { get; set; }
        public List<string>? Tags { get; set; }
        public List<string>? Images { get; set; }
        public string? Video { get; set; }
        public string? Document { get; set; }
        public bool? HasOfferPackages { get; set; }
        public PackageDto? BasicPackage { get; set; } = null!;
        public PackageDto? StandardPackage { get; set; }
        public PackageDto? PremiumPackage { get; set; }
    }
}
