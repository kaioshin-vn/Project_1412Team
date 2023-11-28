using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Models
{
    public class GiamGia
    {
        [Key]
        int id { get; set; }

        int? PhanTramGiamGia { get; set; }

        bool ? TrangThai { get; set; }
    }
}
