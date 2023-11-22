using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(5)]
        public int Sex { get; set; }
        public bool Visible { get; set; }

        // quan hệ
        public virtual ICollection<Bill> Bills { get; set; }
        //public virtual ICollection<MedicalBill> MedicalBills { get; set; }


    }
}
