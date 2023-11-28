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
    public class ChamCong
    {
        [Key]
        public Guid IdNhanVien { get; set; }
        public DateTime? ThoiGianBatDau {  get; set; }
        public DateTime? ThoiGianKetThuc {  get; set; }

        public bool? TrangThaiCham { get; set; }
        // quan hệ
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien? NhanVien { get; set; }
        //public virtual ICollection<Luong>? Luong { get; set; }
    }
}
