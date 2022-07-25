using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using static CliverApi.Common.Enum;

namespace CliverApi.Models
{
    [Table("Package")]
    public class Package
    {
        public Package()
        {
            IsAvailable = true;
        }
        [ForeignKey("Student")]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public int DeliveryTime { get; set; }
        public int? NumberOfPages { get; set; }
        public bool CanDesignCustomized { get; set; }
        public bool CanContentUpload { get; set; }
        public bool IsResponsiveDesign { get; set; }
        public bool HasSourceCode { get; set; }
        public int? NumberOfRevisions { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        [Column(TypeName = "varchar(12)")]
        public PackageType Type { get; set; }
    }

    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasIndex(e => e.Type);
            builder
                .Property(b => b.IsAvailable)
                .HasDefaultValue(true);
            builder
                .Property(b => b.Type)
                .HasDefaultValue(PackageType.Basic);
        }
    }
}
