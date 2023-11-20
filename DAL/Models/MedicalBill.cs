using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class MedicalBill
    {
        public Guid Id { get; set; }
        public Guid IdDoctor { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdNurse { get; set; }
        public Guid IdShift { get; set; }
        public Guid IdClinic { get; set; }
        public Guid IdService { get; set; }
        public Guid IdDate { get; set; }
        public string Status { get; set; }
        public bool Visible { get; set; }
       
    }
}
