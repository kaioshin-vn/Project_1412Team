using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Dịch vụ")]
    public class Service
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; } // mô tả
        public int Price { get; set; } // giá


    }
}
