using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Shift
    {
        public Guid Id { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime TimeStart { get; set; }
    }
}
