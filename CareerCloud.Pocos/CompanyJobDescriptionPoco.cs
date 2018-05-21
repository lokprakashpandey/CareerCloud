using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions", Schema = "dbo")]
    class CompanyJobDescriptionPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Jobs_Id")]
        public Guid Job { get; set; }

        [Column("Job_Name", TypeName = "nvarchar")]
        [StringLength(100)]
        public String JobName { get; set; }

        [Column("Job_Descriptions", TypeName = "nvarchar")]
        [StringLength(1000)]
        public String JobDescription { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        
    }
}
