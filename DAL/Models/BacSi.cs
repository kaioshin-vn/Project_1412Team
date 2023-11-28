using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("BacSi")]
    public class BacSi
    {
        [Key]
        public Guid IdBacSi { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        [Required]
        DateTime? NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        public bool? HienThi { get; set; } // ẩn hiện

        // quan hệ
       [ForeignKey("IdBacSi")]
        public virtual NhanVien? NhanVien { get; set; }
      
        public virtual ICollection< PhieuKham>? PhieuKham { get; set; }
    }
}
