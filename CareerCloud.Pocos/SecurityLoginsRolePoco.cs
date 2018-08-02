using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles", Schema = "dbo")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Login { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Role { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }

        public virtual SecurityRolePoco SecurityRoles { get; set; }

    }
}
