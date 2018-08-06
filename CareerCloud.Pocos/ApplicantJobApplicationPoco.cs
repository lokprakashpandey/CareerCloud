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
        public Guid Applicant { get; set; }

        [Required]
        public Guid Job { get; set; }

        [Required]
        [Column("Application_Date", TypeName = "datetime2")]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }
        
        [ForeignKey("Applicant")]
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }

        [ForeignKey("Job")]
        public virtual CompanyJobPoco CompanyJobs { get; set; }


    }
}
