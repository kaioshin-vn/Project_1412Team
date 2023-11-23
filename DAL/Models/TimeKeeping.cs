using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ChamCong")]
    public class TimeKeeping
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdStaff { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // quan hệ
        public virtual Staff Staff { get; set; }
    }
}
