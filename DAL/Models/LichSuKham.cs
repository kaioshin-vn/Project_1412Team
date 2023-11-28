using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("LichSuKham")]
    public class LichSuKham
    {
        //Thọ
        [Key]
        public Guid IdPhieuKham { get; set; }
        [Required]
        public string? KetQua { get; set; } // kết quả
        public string? GhiChu { get; set; }
        [ForeignKey("IdPhieuKham")] 
        
        public virtual PhieuKham? MedicalBills { get; set; }

    }
}
