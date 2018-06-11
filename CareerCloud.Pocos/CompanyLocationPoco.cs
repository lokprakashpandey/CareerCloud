using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations", Schema = "dbo")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Profiles_Id")]
        public Guid Company { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Column("Country_Code", TypeName = "char")]
        public String CountryCode { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Column("State_Province_Code", TypeName = "char")]
        public String Province { get; set; }

        [StringLength(100)]
        [Column("Street_Address", TypeName = "nvarchar")]
        public String Street { get; set; }

        [StringLength(100)]
        [Column("City_Town", TypeName = "nvarchar")]
        public String City { get; set; }

        [StringLength(20, MinimumLength = 20)]
        [Column("Zip_Postal_Code", TypeName = "char")]
        public string PostalCode { get; set; }

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        
    }
}
