using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("PhieuKham")]
    public class PhieuKham
    {
        [Key]
        public Guid IdPhieuKham { get; set; }
        public Guid IdBacSi { get; set; }
        public Guid IdDichVu { get; set; }
        public int CaKham { get; set; }
        public Guid IdPhong { get; set; }
        public Guid IdKhachHang { get; set; }
        public Guid? IdYTa{ get; set; }
        public DateTime ngayKham { get; set; }

        public bool? TrangThai { get; set; }
        public bool? HienThi { get; set; }

        // Thọ
        public virtual ICollection< HoaDonChiTiet>? BillDetail { get; set; }

        public virtual LichSuKham? HealtRecord { get; set; }
        public virtual ICollection< DanhGia>? Rate { get; set; }

        [ForeignKey("IdDichVu")]
        public virtual DichVu? Service { get; set; }
        [ForeignKey("IdPhong")]

        public virtual Phong? Clinic { get; set; }
        [ForeignKey("IdKhachHang")]
        public virtual KhachHang? Customers { get; set; }
    }
}
