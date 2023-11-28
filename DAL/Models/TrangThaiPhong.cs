using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("TrangThaiPhong")]
    public class TrangThaiPhong
    {
        [Key]
        public int IdNgay { get; set; }
        public bool? TrangThai { get; set; }

        public DateTime Ngay { get; set; }
        public Guid IdPhong { get; set; }
        public Guid IdCaKham { get; set; }
        [ForeignKey("IdPhong")]
        public virtual Phong? Phong { get; set; }
        [ForeignKey("IdCaKham")]
        public virtual CaKham? CaKham { get; set; }

    }
}
