using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class HealtRecord
    {
        public int Id { get; set; }
        public string Result { get; set; } // kết quả
        public string Notification { get; set; } 
    }
}
