using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        [Required, Phone]
        public string NumberPhone { get; set;}
        [Required]
        public string Posittion { get; set;}
        [Required]
        public int Status { get; set;} // trạng thái

        // quan hệ
        public virtual Admin Admin { get; set; }
        //public virtual Salary Salary { get; set; }
        public virtual TimeKeeping TimeKeeping { get; set; }
        public virtual Doctor Doctor { get; set; }
        //public virtual Nurse Nurse { get; set; }
        //public virtual Notice Notice { get; set; }
    }
}
