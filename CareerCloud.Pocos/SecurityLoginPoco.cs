using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins", Schema = "dbo")]
    public class SecurityLoginPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public String Login { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public String Password { get; set; }

        [Required]
        [Column("Created_Date", TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column("Password_Update_Date", TypeName = "datetime2")]
        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date", TypeName = "datetime2")]
        public DateTime? AgreementAccepted { get; set; }

        [Required]
        [Column("Is_Locked", TypeName = "bit")]
        public Boolean IsLocked { get; set; }

        [Required]
        [Column("Is_Inactive", TypeName = "bit")]
        public Boolean IsInactive { get; set; }

        [Required]
        [Column("Email_Address", TypeName = "varchar")]
        [StringLength(50)]
        public String EmailAddress { get; set; }

        [Column("Phone_Number", TypeName = "varchar")]
        [StringLength(20)]
        public String PhoneNumber { get; set; }

        [Column("Full_Name", TypeName = "nvarchar")]
        [StringLength(100)]
        public String FullName { get; set; }

        [Required]
        [Column("Force_Change_Password", TypeName = "bit")]
        public Boolean ForceChangePassword { get; set; }

        [Column("Prefferred_Language", TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public String PrefferredLanguage { get; set; }

        
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }

        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }

        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }

    }
}
