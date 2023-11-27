using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ChamCong")]
    public class TimeKeeping
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string NameNV { get; set; }
        public int NgayCong { get; set; }
        public decimal Luong { get; set; }
        // quan hệ
        public virtual ICollection<Staff>? Staff { get; set; }
    }
}
