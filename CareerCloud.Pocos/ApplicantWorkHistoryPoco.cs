﻿using System;
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
        public Char[] CountryCode;

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public String Location;

        [Required]
        [StringLength(50)]
        [Column("Job_Title", TypeName = "nvarchar")]
        public String JobTitle;

        [Required]
        [StringLength(500)]
        [Column("Job_Description", TypeName = "nvarchar")]
        public String JobDescription;

        [Required]
        [Column("Start_Month")]
        public Int16 StartMonth;

        [Required]
        [Column("Start_Year")]
        public Int32 StartYear;

        [Required]
        [Column("End_Month")]
        public Int16 EndMonth;

        [Required]
        [Column("End_Year")]
        public Int32 EndYear;

        [Required]
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp;

    }
}
