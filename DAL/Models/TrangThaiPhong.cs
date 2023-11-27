using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("TrangThaiPhongKham")]
    public class TrangThaiPhong
    {
        [Key]
        public int IndexDate { get; set; }
        public string Status { get; set; }
        public Guid IdShift { get; set; }
        public Guid IdClinic { get; set; }
        public virtual ICollection<Phong>? Clinics { get; set; }
        public virtual ICollection<CaKham>? Shifts { get; set; }

    }
}
