using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TimeKeeping
    {
        public Guid IdStaff { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // quan hệ
        public virtual Staff Staff { get; set; }
       
    }
}
