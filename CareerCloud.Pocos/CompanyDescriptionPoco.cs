using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions", Schema = "dbo")]
    class CompanyDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Profiles_Id")]
        public Guid Company { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [ForeignKey("System_Language_Codes_LanguageID")]
        [Column(TypeName = "char")]
        public char[] LanguageID { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Company_Name", TypeName = "nvarchar")]
        public String CompanyName { get; set; }

        [Required]
        [StringLength(1000)]
        [Column("Company_Description", TypeName = "nvarchar")]
        public String CompanyDescription { get; set; }

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
#pragma warning disable CS0649 // Field 'CompanyDescriptionPoco.TimeStamp' is never assigned to, and will always have its default value null
        public Byte[] TimeStamp;
#pragma warning restore CS0649 // Field 'CompanyDescriptionPoco.TimeStamp' is never assigned to, and will always have its default value null
        
    }
}
