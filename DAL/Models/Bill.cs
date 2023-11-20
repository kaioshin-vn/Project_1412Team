using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public string IdNurse { get; set; }
        public string IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethods { get; set; } // Phương thức thanh toán
        public string Note {  get; set; } // ghi chú
    }
}
