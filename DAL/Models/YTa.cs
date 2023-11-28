using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("YTa")]
    public class YTa
    {
        [Key]
        public Guid IdYTa { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        [Required]
        DateTime? NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        public bool? HienThi { get; set; } // ẩn hiện

        // quan hệ
        [ForeignKey("IdYTa")]
        public virtual NhanVien? NhanVien { get; set; }

        public virtual ICollection<PhieuKham>? PhieuKham { get; set; }

    }
}
