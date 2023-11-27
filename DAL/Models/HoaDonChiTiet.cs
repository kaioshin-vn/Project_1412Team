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
    [Table("HoaDonChiTiet")]
    public class HoaDonChiTiet
    {
        // Thọ
        [Key]
        public Guid Id { get; set; }
        public Status Status { get; set; } // trạng thái
        public virtual HoaDon? Bill { get; set; }
        public virtual ICollection<PhieuKham> MedicalBills { get; set; }
    }
}
