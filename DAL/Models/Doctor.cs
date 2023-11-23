using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("BacSi")]
    public class Doctor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 1)]
        public  int Gender { get; set; } //giới tính
        [Required, Phone]
        public string NumberPhone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool visible { get; set; } // ẩn hiện

        // quan hệ
        public virtual Staff? Staff { get; set; }
        public virtual StatusDoctor? StatusdDoctor { get; set; }
        public virtual MedicalBill? MedicaBill { get; set; }
    }
}
