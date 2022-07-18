using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Kensa.Common.Enum;

namespace CliverApi.Models
{
    [Table("User")]
    public class User : AuditEntity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Posts = new HashSet<Post>();
            Type = UserType.User;
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long NetIncome { get; set; }
        public long Withdrawn { get; set; }
        public long UsedFor { get; set; }
        public long UsedForPurchases { get; set; }
        public long Amount { get; set; }
        public long PendingClearance { get; set; }
        public long AvailableForWithdrawal { get; set; }
        public UserType Type { get; set; }
        public bool IsActived { get; set; }
        public ICollection<Post> Posts{ get; set; }

    }
}
