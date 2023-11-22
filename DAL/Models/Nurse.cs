using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("YTa")]
    public class Nurse
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 1)]
        public int Gender { get; set; } // giới tính
        [Required, Phone]
        public string NumberPhone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Visible { get; set; } // ẩn hiện

        // quan hệ
        public virtual Staff Staff { get; set; }
        //public virtual MedicaBill MedicaBill { get; set; }

        // Thọ
        public virtual Bill? Bill { get; set; }

    }
}
