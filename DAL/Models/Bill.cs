using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string IdNurse { get; set; }
        public string IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethods { get; set; } // Phương thức thanh toán
        [MaxLength(100)]
        public string Note {  get; set; } // ghi chú
    }
}
