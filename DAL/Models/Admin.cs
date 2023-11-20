using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Passwprd {  get; set; }
        [Required]
        public bool Visible { get; set; } // ẩn hiện

        // quan hệ
        public virtual Staff Staff { get; set; }
    }
}
