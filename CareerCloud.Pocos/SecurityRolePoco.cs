using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles", Schema = "dbo")]
    class SecurityRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public String Role { get; set; }

        [Required]
        [Column("Is_Inactive", TypeName = "bit")]
        public Boolean IsInactive { get; set; }

    }
}
