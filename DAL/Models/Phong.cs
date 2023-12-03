using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Phong")]
    public class Phong
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public LoaiPhong LoaiPhong { get; set; }

        public virtual ICollection<TrangThaiPhong>? TrangThaiPhongs { get; set; }
        public virtual ICollection<PhieuKham>? PhieuKhams { get; set; }
    }
}
