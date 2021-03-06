﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations", Schema = "dbo")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid Company { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Column("Country_Code", TypeName = "char")]
        public String CountryCode { get; set; }

        [Column("State_Province_Code")]
        public String Province { get; set; }

        [StringLength(100)]
        [Column("Street_Address", TypeName = "nvarchar")]
        public String Street { get; set; }

        [StringLength(100)]
        [Column("City_Town", TypeName = "nvarchar")]
        public String City { get; set; }

        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }

        
        [Column("Time_Stamp", TypeName = "timestamp")]
        public Byte[] TimeStamp { get; set; }

        [ForeignKey("Company")]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }

    }
}
