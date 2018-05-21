using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes", Schema = "dbo")]
    class SystemLanguageCodePoco
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(10, MinimumLength = 10)]
        public char[] LanguageID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [Column("Native_Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public String NativeName { get; set; }

    }
}
