using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Domain.Entities
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public long Id { get; protected set; }

        [Required, StringLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
