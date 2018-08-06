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
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        
        //[ForeignKey("Company")]
        [Required]
        public Guid Company { get; set; }

        [Required]
        [Column("LanguageID")]
        public string LanguageId { get; set; }

        [Required]
        [Column("Company_Name")]
        public string CompanyName { get; set; }

        [Required]
        [Column("Company_Description")]
        public string CompanyDescription { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        [ForeignKey("Company")]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }

        [ForeignKey("LanguageID")]
        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }

    }



    //    [Table("Company_Descriptions", Schema = "dbo")]
    //    public class CompanyDescriptionPoco : IPoco
    //    {
    //        [Key]
    //        public Guid Id { get; set; }

    //        [Required]
    //        public Guid Company { get; set; }

    //        [Required]
    //        [Column("LanguageID",TypeName = "char")]
    //        [StringLength(10, MinimumLength = 10)]
    //        public String LanguageId { get; set; }

    //        [Required]
    //        [StringLength(50)]
    //        [Column("Company_Name", TypeName = "nvarchar")]
    //        public String CompanyName { get; set; }

    //        [Required]
    //        [StringLength(1000)]
    //        [Column("Company_Description", TypeName = "nvarchar")]
    //        public String CompanyDescription { get; set; }

    //        [Required]
    //        [Column("Time_Stamp")]
    //#pragma warning disable CS0649 // Field 'CompanyDescriptionPoco.TimeStamp' is never assigned to, and will always have its default value null
    //        public Byte[] TimeStamp { get; set; }
    //#pragma warning restore CS0649 // Field 'CompanyDescriptionPoco.TimeStamp' is never assigned to, and will always have its default value null
    //        public virtual CompanyProfilePoco CompanyProfiles { get; set; }

    //        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    // }
}

