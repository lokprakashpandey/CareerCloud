using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Applicant_Profiles_Id")]
        public Guid Applicant { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Jobs_Id")]
        public Guid Job { get; set; }

        [Required]
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }
}
