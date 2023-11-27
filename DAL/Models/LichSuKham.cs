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
        public Guid Id { get; set; }
        public string? Result { get; set; } // kết quả
        public string? Notification { get; set; } 
        public virtual ICollection<PhieuKham>? MedicalBills { get; set; }

    }
}
