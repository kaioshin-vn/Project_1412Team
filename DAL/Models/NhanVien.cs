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
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public Guid IdNhanVien { get; set; }
        [Required]
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        [Required]
        [MaxLength(15)]
        public string? SoDienThoai { get; set; }

        [Required]
        public DateTime? NgaySinh { get; set; }
        [Required]
        public bool? GioiTinh { get; set; }
        public bool? HienThi { get; set; } // ẩn hiện
        [Required]
        public LoaiNhanVien ChucVu { get; set;}
        public bool? TrangThai { get; set;} // trạng thái

        [Required]
        public string? MatKhau { get; set; }

        public string? Mota { get;set; }

        // quan hệ



        public virtual ICollection<ChamCong> ChamCong { get; set; }
        public virtual ICollection<ThongBao>? ThongBao { get; set; }
        public virtual ICollection<TrangThaiNhanVien>? TrangThaiNhanVien { get; set; }
    }
}
