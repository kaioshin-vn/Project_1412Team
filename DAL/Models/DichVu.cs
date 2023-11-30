using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("DichVu")]
    public class DichVu
    {
        //Thọ
        [Key]
        public Guid IdDichVu { get; set; }
        [Required]
        public string? Ten { get; set; }
        [Required]
        public string? MoTa { get; set; } // mô tả
        [Required]
        public double Gia { get; set; } // giá

        public bool? HienThi { get; set; } 

        public virtual ICollection<PhieuKham>? MedicalBills { get; set; }

    }
}
