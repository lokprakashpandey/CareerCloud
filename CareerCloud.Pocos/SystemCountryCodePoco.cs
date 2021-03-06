﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes", Schema = "dbo")]
    public class SystemCountryCodePoco
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public String Code { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public String Name { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> GetApplicantWorkHistories { get; set; }
    }
}
