using Microsoft.EntityFrameworkCore;
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
        public int Id { get; set; }

        public string TrangThai { get; set; } = "false|false|false|false|false|false|false|false";
        public Guid IdNhanVien { get; set; }
        public DateTime Ngay { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien? NhanVien { get; set; }
    }
}
