using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Luong")]
    public class Luong
    {
        [Key]
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public double Bonus { get; set; }
        public DateTime Time { get; set; }
        public int AmountShifts { get; set; }


        // quan hệ
        public virtual NhanVien Staff { get; set; }
        public virtual ICollection< ThongKe>? Statiscals { get; set; }
    }
}
