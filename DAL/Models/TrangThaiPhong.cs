using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("TrangThaiPhong")]
    public class TrangThaiPhong
    {
        [Key]
        public int Id { get; set; }
        public string TrangThai { get; set; } = "false|false|false|false|false|false|false|false";

        public DateTime Ngay { get; set; }
        public Guid IdPhong { get; set; }

        [ForeignKey("IdPhong")]
        public virtual Phong? Phong { get; set; }


    }
}
