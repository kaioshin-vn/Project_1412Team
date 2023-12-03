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
    [Table("ThongBao")]
    public  class ThongBao
    {
        [Key]
        public Guid IdThongBao { get; set; }
        public string? TinNhan { get; set; }
        public bool? TrangThai { get; set; }
        public TrangThaiXacNhan TTChapNhan { get; set; }

        public Guid IdNguoiGui { get; set; }

        // quan hệ
        [ForeignKey("IdNguoiGui")]
        public virtual NhanVien? Staff { get; set; }
    }
}
