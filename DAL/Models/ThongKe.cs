using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ThongKe")]
    public class ThongKe
    {
        [Key]
        public Guid Id { get; set; }
        public Statis Type { get; set; }
        public string Note { get; set; }


        // quan hệ
        public virtual HoaDon Bill { get; set; }
        public virtual Luong Salary { get; set; }

    }
}
