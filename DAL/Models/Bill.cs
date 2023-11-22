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
    [Table("Hóa đơn")]
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        //public string IdNurse { get; set; }
        //public string IdCustomer { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public PaymentMethods PaymentMethods { get; set; } // Phương thức thanh toán
        public string? Note {  get; set; } // ghi chú
        public virtual ICollection<BillDetail> BillDetails { get; set; }

    }
}
