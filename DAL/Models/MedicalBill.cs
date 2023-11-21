using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MedicalBill
    {
        public Guid Id { get; set; }
        public Guid IdDoctor { get; set; }
        public virtual Doctor Doctor { get; set; }
        public Guid IdCustomer { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid IdNurse { get; set; }
        public virtual Nurse Nurse { get; set; }
        public Guid IdShift { get; set; }
        public virtual Shift Shift { get; set; }
        public Guid IdClinic { get; set; }
        public virtual Clinic Clinic { get; set; }
        public Guid IdService { get; set; }
        public virtual Service Service { get; set; }
        public Guid IdRate { get; set; }
        public virtual Rate Rate { get; set; }
        public string Status { get; set; }
        public bool Visible { get; set; }
    }
}
