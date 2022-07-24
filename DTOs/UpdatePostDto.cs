using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class UpdatePostDto
    {
        public UpdatePostDto()
        {
        }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? SubcategoryId { get; set; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private List<string>? _tags { get; set; }
        public List<string>? Tags
        {
            get { return _tags; }
            set
            {
                _tags = value?.Select(s => s.Trim().Replace(";", "")).ToList();
            }
        }
        public List<string>? _images { get; set; }
        public List<string>? Images
        {
            get { return _images; }
            set
            {
                _images = value?.Select(s => s.Trim().Replace(";", "")).ToList();
            }
        }
        public string? Video { get; set; }
        public string? Document { get; set; }
        public bool? HasOfferPackages { get; set; }
        public PackageDto? BasicPackage { get; set; } = null!;
        public PackageDto? StandardPackage { get; set; }
        public PackageDto? PremiumPackage { get; set; }
    }
}
