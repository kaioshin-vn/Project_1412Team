using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("HoaDon")]
    public class Bill
    {
        // Thọ
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenKH { get; set; }
        public string DichVu { get; set; }

        public DateTime NgayTao { get; set; }
        public decimal? TongTien { get; set; }
        public string? PaymentMethods { get; set; } // Phương thức thanh toán
        public string? Note {  get; set; } // ghi chú
        public virtual ICollection<BillDetail>? BillDetails { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
        public virtual ICollection<Nurse>? Nurses { get; set; }
    }
}
