using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("DanhGia")]
    public class DanhGia
    {
        // Thọ
        [Key]
        public Guid IdDanhGia { get; set; }
        [Required]
        public string? NoiDung { get; set; }
        public Guid IdPhieuKham { get; set; }
        public DateTime NgayTao { get; set; }

        public bool? HienThi {  get; set; }

        [ForeignKey("IdPhieuKham")]
        public virtual PhieuKham? PhieuKham { get; set; }
    }
}
