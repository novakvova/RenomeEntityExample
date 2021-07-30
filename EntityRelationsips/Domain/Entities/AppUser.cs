using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Domain.Entities
{
    [Table("tblUsers")]
    public class AppUser
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
