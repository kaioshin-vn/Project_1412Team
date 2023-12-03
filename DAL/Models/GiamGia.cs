using DAL.Models;
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
        public int id { get; set; }

        public int? PhanTramGiamGia { get; set; }

        public bool ? TrangThai { get; set; }

        public virtual ICollection<HoaDon>? HoaDons { get; set; }
    }
}
