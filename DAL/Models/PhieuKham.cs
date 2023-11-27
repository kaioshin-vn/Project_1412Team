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
        public Guid Id { get; set; }
        
        public string? Status { get; set; }
        public bool Visible { get; set; }

        // Thọ
        public virtual HoaDonChiTiet? BillDetail { get; set; }
        public virtual LichSuKham? HealtRecord { get; set; }
        public virtual DanhGia? Rate { get; set; }
        public virtual DichVu? Service { get; set; }
        public virtual ICollection<TrangThaiBacSi>? StatusDoctors { get; set; }
        public virtual Phong? Clinic { get; set; }
        public virtual ICollection<BacSi>? Doctors { get; set; }
        public virtual ICollection<CaKham>?  Shifts { get; set; }
        public virtual ICollection<KhachHang>? Customers { get; set; }


    }
}
