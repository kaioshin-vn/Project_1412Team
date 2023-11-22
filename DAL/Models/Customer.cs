using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("KhanhHang")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public int Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(5)]
        public int Sex { get; set; }
        public string DichVu { get; set; }
        public bool Visible { get; set; }

        // quan hệ
        //public virtual ICollection<MedicalBill> MedicalBills { get; set; }

        // Thọ
        public virtual Bill? Bills { get; set; }
        public virtual MedicalBill? MedicalBill { get; set; }

    }
}
