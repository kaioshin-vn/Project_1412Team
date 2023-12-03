using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Luong")]
    public class Luong
    {
        [Key]
        public Guid IdLuong { get; set; }
        public bool? TrangThai { get; set; }
        public double? Thuong { get; set; }
        public DateTime? ThoiGian { get; set; }
        public int? SoCong { get; set; }
        public Guid IdNhanVien { get; set; }

        // quan hệ
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien? NhanVien { get; set; }
        public virtual ICollection< ThongKe>? ThongKe { get; set; }
    }
}
