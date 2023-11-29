using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public Guid IdKhachHang { get; set; }

        [Required]
        public string? Ten { get; set; }

        [Required]
        [MaxLength(15)]
        public string? SoDienThoai { get; set; }

        [Required]
        public string? DiaChi { get; set; }
        [Required]
        public DateTime? NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        public bool? HienThi { get; set; } // ẩn hiện

        // quan hệ
        //public virtual ICollection<MedicalBill> MedicalBills { get; set; }

        // Thọ
        
        public virtual ICollection<PhieuKham>? MedicalBill { get; set; }

    }
}
