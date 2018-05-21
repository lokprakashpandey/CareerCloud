using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles", Schema = "dbo")]
    class ApplicantProfilePoco
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Security_Logins_Id")]
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        [DataType("decimal(18,0)")]
        public Decimal CurrentSalary { get; set; }

        [Column("Current_Rate")]
        [DataType("decimal(18,2)")]
        public Decimal CurrentRate { get; set; }

        [Column(TypeName="char")]
        [StringLength(10, MinimumLength = 10)]
        public String Currency { get; set; }

        [Column("Country_Code", TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        [ForeignKey("System_Country_Codes_Code")]
        public String CountryCode { get; set; }

        [Column("State_Province_Code", TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public String StateProvinceCode { get; set; }

        [Column("Street_Address", TypeName = "nvarchar")]
        [StringLength(100)]
        public String StreetAddress { get; set; }

        [Column("City_Town", TypeName = "nvarchar")]
        [StringLength(100)]
        public String CityTown { get; set; }

        [Column("Zip_Postal_Code", TypeName = "char")]
        [StringLength(20, MinimumLength = 20)]
        public String ZipPostalCode { get; set; }

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

    }
}
