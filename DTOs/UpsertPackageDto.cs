using CliverApi.Models;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class UpsertPackageDto
    {
        public UpsertPackageDto()
        {
        }
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? PostId { get; set; }
        public int DeliveryTime { get; set; }
        public int? NumberOfPages { get; set; }
        public bool CanDesignCustomized { get; set; }
        public bool CanContentUpload { get; set; }
        public bool IsResponsiveDesign { get; set; }
        public bool HasSourceCode { get; set; }
        public int? NumberOfRevisions { get; set; }
        public int Price { get; set; }
        public PackageType Type { get; set; }
    }

    class UpsertPackageDtoEqualityComparer : IEqualityComparer<UpsertPackageDto>
    {
        public bool Equals(UpsertPackageDto? x, UpsertPackageDto? y)
        {
            return x?.Id == y?.Id || x?.Type == y?.Type;
         }

        public int GetHashCode(UpsertPackageDto obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
