using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Domain.Entities
{
    [Table("tblRoles")]
    public class AppRole
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
