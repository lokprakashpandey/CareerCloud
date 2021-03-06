﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles", Schema = "dbo")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        [DataType("decimal(18,0)")]
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        [DataType("decimal(18,2)")]
        public Decimal? CurrentRate { get; set; }

        [Column(TypeName="char")]
        [StringLength(10, MinimumLength = 10)]
        public String Currency { get; set; }

        [Column("Country_Code", TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public String Country { get; set; }

        [Column("State_Province_Code", TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public String Province { get; set; }

        [Column("Street_Address", TypeName = "nvarchar")]
        [StringLength(100)]
        public String Street { get; set; }

        [Column("City_Town", TypeName = "nvarchar")]
        [StringLength(100)]
        public String City { get; set; }

        [Column("Zip_Postal_Code", TypeName = "char")]
        [StringLength(20, MinimumLength = 20)]
        public String PostalCode { get; set; }

        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }

        [ForeignKey("Login")]
        public virtual SecurityLoginPoco SecurityLogins { get; set; }

        [ForeignKey("Country")]
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }

        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}
