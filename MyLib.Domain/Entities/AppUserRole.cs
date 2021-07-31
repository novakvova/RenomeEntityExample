using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Domain.Entities
{
    [Table("tblUserRoles")]
    public class AppUserRole
    {
        public long UserId { get; set; }
        public virtual AppUser User { get; set; }
        public long RoleId { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
