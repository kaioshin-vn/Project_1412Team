using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("PhieuKham")]
    public class MedicalBill
    {
        [Key]
        public Guid Id { get; set; }
        
        public string? Status { get; set; }
        public bool Visible { get; set; }

        // Thọ
        public virtual BillDetail? BillDetail { get; set; }
        public virtual HealtRecord? HealtRecord { get; set; }
        public virtual Rate? Rate { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ICollection<StatusDoctor>? StatusDoctors { get; set; }
        public virtual Clinic? Clinic { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Shift>?  Shifts { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }


    }
}
