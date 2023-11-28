using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ThongKe")]
    public class ThongKe
    {
        [Key]
        public Guid IdThongKe { get; set; }
        public bool LoaiThongKe { get; set; }
        public string? GhiChu { get; set; }
       
        public Guid? IdHoaDon { get; set; }

        public Guid? IdLuong { get; set; }


        // quan hệ
        [ForeignKey("IdHoaDon")]
        public virtual HoaDon? HoaDon { get; set; }
        [ForeignKey("IdLuong")]
        public virtual Luong? Luong { get; set; }

    }
}
