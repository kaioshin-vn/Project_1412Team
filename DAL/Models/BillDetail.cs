using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BillDetail
    {
        public Guid Id { get; set; }
        public Status Status { get; set; } // trạng thái
    }
}
