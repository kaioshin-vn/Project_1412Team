using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Statiscal
    {
        public Guid Id { get; set; }
        public Statis Type { get; set; }
        public string Note { get; set; }


        // quan hệ
        public virtual Bill Bill { get; set; }
        public virtual Salary Salary { get; set; }

    }
}
