using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills", Schema = "dbo")]
    class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Applicant_Profiles_Id")]
        public Guid Applicant { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public String Skill { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Column("Skill_Level", TypeName = "char")]
        public Char[] SkillLevel { get; set; }

        [Required]
        [Column("Start_Month")]
        public Byte StartMonth { get; set; }

        [Required]
        [Column("Start_Year")]
        public Int32 StartYear { get; set; }

        [Required]
        [Column("End_Month")]
        public Byte EndMonth { get; set; }

        [Required]
        [Column("End_Year")]
        public Int32 EndYear { get; set; }

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }
    }
}
