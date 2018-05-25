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
    class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Applicant_Profiles_Id")]
        public Guid Applicant { get; set; }

        [Required]
        [StringLength(150)]
        [Column("Company_Name", TypeName = "nvarchar")]
        public String CompanyName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [ForeignKey("System_Country_Codes_Code")]
        [Column("Country_Code", TypeName = "char")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.CountryCode' is never assigned to, and will always have its default value null
        public String CountryCode;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.CountryCode' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.Location' is never assigned to, and will always have its default value null
        public String Location;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.Location' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(50)]
        [Column("Job_Title", TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.JobTitle' is never assigned to, and will always have its default value null
        public String JobTitle;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.JobTitle' is never assigned to, and will always have its default value null

        [Required]
        [StringLength(500)]
        [Column("Job_Description", TypeName = "nvarchar")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.JobDescription' is never assigned to, and will always have its default value null
        public String JobDescription;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.JobDescription' is never assigned to, and will always have its default value null

        [Required]
        [Column("Start_Month")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.StartMonth' is never assigned to, and will always have its default value 0
        public Int16 StartMonth;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.StartMonth' is never assigned to, and will always have its default value 0

        [Required]
        [Column("Start_Year")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.StartYear' is never assigned to, and will always have its default value 0
        public Int32 StartYear;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.StartYear' is never assigned to, and will always have its default value 0

        [Required]
        [Column("End_Month")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.EndMonth' is never assigned to, and will always have its default value 0
        public Int16 EndMonth;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.EndMonth' is never assigned to, and will always have its default value 0

        [Required]
        [Column("End_Year")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.EndYear' is never assigned to, and will always have its default value 0
        public Int32 EndYear;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.EndYear' is never assigned to, and will always have its default value 0

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
#pragma warning disable CS0649 // Field 'ApplicantWorkHistoryPoco.TimeStamp' is never assigned to, and will always have its default value null
        public Byte[] TimeStamp;
#pragma warning restore CS0649 // Field 'ApplicantWorkHistoryPoco.TimeStamp' is never assigned to, and will always have its default value null

    }
}
