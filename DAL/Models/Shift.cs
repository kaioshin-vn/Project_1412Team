using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("CaKham")]
    public class Shift
    {
        [Key]
        public Guid Id { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime TimeStart { get; set; }
        public virtual StatusClinic? StatusClinic { get; set; }  
        public virtual MedicalBill? MedicalBill { get; set; }
    }
}
