using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes", Schema = "dbo")]
    public class ApplicantResumePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public String Resume { get; set; }

        [Column("Last_Updated", TypeName = "datetime2")]
        public DateTime? LastUpdated { get; set; }

        [ForeignKey("Applicant")]
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }

    }
}
