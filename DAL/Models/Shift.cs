using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shift
    {
        public Guid Id { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime TimeStart { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
