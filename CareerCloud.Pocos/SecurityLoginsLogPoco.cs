using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log", Schema = "dbo")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Login { get; set; }

        [Required]
        [Column("Source_IP", TypeName = "char")]
        [StringLength(15, MinimumLength = 15)]
        public String SourceIP { get; set; }

        [Required]
        [Column("Logon_Date", TypeName = "datetime")]
        public DateTime LogonDate { get; set; }

        [Required]
        [Column("Is_Succesful", TypeName = "bit")]
        public Boolean IsSuccesful { get; set; }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }

    }
}
