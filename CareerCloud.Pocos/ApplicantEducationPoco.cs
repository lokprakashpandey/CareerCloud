using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]//since foreign keys may be null
        [Index(IsUnique =true)]
        [ForeignKey("Applicant_Profiles_Id")]//don't know much
        public Guid Applicant { get; set; }

        [Required]
        [StringLength(100)]
        public String Major { get; set; }

        [StringLength(100)]
        [Column("Certificate_Diploma")]
        public String CertificateDiploma { get; set; }

        [Column("Start_Date")]
        public DateTime StartDate { get; set; }

        [Column("Completion_Date")]
        public DateTime CompletionDate { get; set; }
        
        [Column("Completion_Percent")]
        public Byte CompletionPercent { get; set; }

        [Required]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }
}
