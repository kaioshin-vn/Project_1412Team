using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } // trạng thái
    }
}
