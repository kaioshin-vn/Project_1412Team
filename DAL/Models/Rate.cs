using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("DanhGia")]
    public class Rate
    {
        // Thọ
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        //public IdMB 
        public virtual ICollection<MedicalBill>? MedicalBills { get; set; }
    }
}
