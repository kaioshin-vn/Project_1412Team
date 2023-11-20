using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class StatusClinic
    {
        [Key]
        public DateTime IndexDate { get; set; }
        public string Status {  get; set; }
        public Guid IdShift { get; set; }
        public Guid IdClinic { get; set; }
    }
}
