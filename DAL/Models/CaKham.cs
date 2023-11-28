using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("CaKham")]
    public class CaKham
    {
        [Key]
        public Guid IdCaKham { get; set; }
        public int STTCaKham { get; set; }
        public virtual ICollection< TrangThaiPhong>? TrangThaiPhong { get; set; }  
        public virtual ICollection< TrangThaiNhanVien>? TrangThaiNhanVien { get; set; }
        public virtual ICollection< PhieuKham>? PhieuKham { get; set; }
    }
}
