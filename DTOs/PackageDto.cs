using CliverApi.Models;
using static Kensa.Common.Enum;

namespace CliverApi.DTOs
{
    public class PackageDto
    {
        public PackageDto()
        {
        }
        public int? Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DeliveryTime { get; set; }
        public int? NumberOfPages { get; set; }
        public bool CanDesignCustomized { get; set; }
        public bool CanContentUpload { get; set; }
        public bool IsResponsiveDesign { get; set; }
        public bool HasSourceCode { get; set; }
        public int? NumberOfRevisions { get; set; }
        public int Price { get; set; }
    }

}
