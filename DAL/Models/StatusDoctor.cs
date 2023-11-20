using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class StatusDoctor
    {
        public DateTime IndexDate { get; set; }
        public string Status {  get; set; }
        public Guid IdShift { get; set; }
        public Guid IdDoctor { get; set; }
        public DateTime Date { get; set; }
    }
}
