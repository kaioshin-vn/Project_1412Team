using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StatusDoctor
    {
        [Key]
        public int IndexDate { get; set; }
        public string Status { get; set; }
        public Guid IdShift { get; set; }
        public Guid IdDoctor { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual MedicalBill? MedicalBill { get; set; }
        public virtual Shift? Shift { get; set; }
    }
}
