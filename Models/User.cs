    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Kensa.Common.Enum;

namespace CliverApi.Models
{
    public class User : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long Amount { get; set; }
        public UserType type { get; set; }
        public bool IsActived { get; set; }
        public bool Actived { get; set; }

    }
}
