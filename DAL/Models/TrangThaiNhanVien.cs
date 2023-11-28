using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("TrangThaiNhanVien")]
    public class TrangThaiNhanVien
    {
        [Key]
        public int IdNgay { get; set; }
        public bool? TrangThai { get; set; }
        public Guid IdCaKham { get; set; }
        public Guid IdNhanVien { get; set; }
        public DateTime Ngay { get; set; }
        public virtual ICollection< PhieuKham>? PhieuKham { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien? NhanVien { get; set; }
        [ForeignKey("IdCaKham")]
        public virtual CaKham? Shift { get; set; }
    }
}
