using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History", Schema = "dbo")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Applicant { get; set; }

        [Required]
        [StringLength(150)]
        [Column("Company_Name", TypeName = "nvarchar")]
        public String CompanyName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Column("Country_Code", TypeName = "char")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.CountryCode' is never assigned to, and will always have its default value null
        public String CountryCode { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.CountryCode' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.Location' is never assigned to, and will always have its default value null
        public String Location { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.Location' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(50)]
        [Column("Job_Title", TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.JobTitle' is never assigned to, and will always have its default value null
        public String JobTitle { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.JobTitle' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(500)]
        [Column("Job_Description", TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.JobDescription' is never assigned to, and will always have its default value null
        public String JobDescription { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.JobDescription' is never assigned to, and will always have its default value null

        [Required]
        [Column("Start_Month")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.StartMonth' is never assigned to, and will always have its default value 0
        public Int16 StartMonth { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.StartMonth' is never assigned to, and will always have its default value 0

        [Required]
        [Column("Start_Year")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.StartYear' is never assigned to, and will always have its default value 0
        public Int32 StartYear { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.StartYear' is never assigned to, and will always have its default value 0

        [Required]
        [Column("End_Month")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.EndMonth' is never assigned to, and will always have its default value 0
        public Int16 EndMonth { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.EndMonth' is never assigned to, and will always have its default value 0

        [Required]
        [Column("End_Year")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.EndYear' is never assigned to, and will always have its default value 0
        public Int32 EndYear { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.EndYear' is never assigned to, and will always have its default value 0

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.TimeStamp' is never assigned to, and will always have its default value null
        public Byte[] TimeStamp { get; set; }
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.TimeStamp' is never assigned to, and will always have its default value null

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }

        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }


    }
}
