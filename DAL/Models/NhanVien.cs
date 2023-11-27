using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ChucVu { get; set; }
        public string Sex { get; set; }
        public string NumberPhone { get; set;}
        public string Address {  get; set;}
        [Required]
        public string Posittion { get; set;}

        [Required]
        public int Status { get; set;} // trạng thái

        // quan hệ
        public virtual Admin? Admin { get; set; }

        //public virtual Salary Salary { get; set; }
        public virtual ChamCong? TimeKeeping { get; set; }
        public virtual BacSi? Doctor { get; set; }
        //public virtual Nurse Nurse { get; set; }
        //public virtual Notice Notice { get; set; }
    }
}
