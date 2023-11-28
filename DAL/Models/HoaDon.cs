﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        // Thọ
        [Key]
        public Guid IdHoaDon { get; set; }
        public Guid? IdNhanVien { get; set; }
        public DateTime? ThoiGian {  get; set; } 

        public string? GhiChu { get; set; }

        public bool? HienThi {  get; set; }
        public virtual ICollection<ThongKe>? ThongKe { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiet { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien? NV { get; set; }
    }
}
