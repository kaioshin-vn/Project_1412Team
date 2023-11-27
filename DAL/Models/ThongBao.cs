using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ThongBao")]
    public  class ThongBao
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Visible { get; set; }

        // quan hệ
        public virtual NhanVien Staff { get; set; }
    }
}
