using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Salary
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public double Bonus { get; set; }
        public DateTime Time { get; set; }
        public int AmountShifts { get; set; }


        // quan hệ
        public virtual Staff Staff { get; set; }
        public virtual ICollection< Statiscal> Statiscals { get; set; }
    }
}
