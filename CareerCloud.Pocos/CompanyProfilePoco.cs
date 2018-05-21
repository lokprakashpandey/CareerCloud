using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles", Schema = "dbo")]
    class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Registration_Date", TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }

        [Column("Company_Website", TypeName = "varchar")]
        [StringLength(100)]
        public String CompanyWebsite { get; set; }

        [Required]
        [Column("Contact_Phone", TypeName = "varchar")]
        [StringLength(20)]
        public String ContactPhone { get; set; }

        [Column("Contact_Name", TypeName = "varchar")]
        [StringLength(50)]
        public String ContactName { get; set; }

        [Column("Company_Logo", TypeName = "varbinary")]
        public Byte[] CompanyLogo { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

    }
}
