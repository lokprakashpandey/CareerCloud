using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications", Schema = "dbo")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Applicant { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid Job { get; set; }

        [Required]
        [Column("Application_Date", TypeName = "datetime2")]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }

        public virtual CompanyJobPoco CompanyJobs { get; set; }


    }
}
