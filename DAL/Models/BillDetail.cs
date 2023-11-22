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
    [Table("Hóa đơn chi tiết")]
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } // trạng thái
        public virtual Bill Bill { get; set; }
    }
}
