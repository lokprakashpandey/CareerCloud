﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills", Schema = "dbo")]
    class CompanyJobSkillPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("Company_Jobs_Id")]
        public Guid Job { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public String Skill { get; set; }

        [Required]
        [StringLength(10)]
        [Column("Skill_Level", TypeName = "varchar")]
        public String SkillLevel { get; set; }

        [Required]
        public Int32 Importance;

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }
        
    }
}
