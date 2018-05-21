using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs", Schema = "dbo")]
    
    class CompanyJobPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Profiles_Id")]
        public Guid Company { get; set; }

        [Required]
        [Column("Profile_Created", TypeName = "datetime2")]
        public DateTime ProfileCreated { get; set; }

        [Required]
        [Column("Is_Inactive", TypeName = "bit")]
        public Boolean IsInactive { get; set; }

        [Required]
        [Column("Is_Company_Hidden", TypeName = "bit")]
        public Boolean IsCompanyHidden { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

    }
}
