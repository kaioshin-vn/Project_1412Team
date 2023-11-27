using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public string MatKhau {  get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public bool HienThi { get; set; } // ẩn hiện

        // quan hệ
        public virtual ICollection<Staff>? Staff { get; set; }
    }
}
