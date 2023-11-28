﻿using DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("HoaDonChiTiet")]
    [PrimaryKey("IdHoaDon" , new string[] { "IdPhieuKham" })]
    public class HoaDonChiTiet
    {
        // Thọ
        [Key]
        public Guid IdHoaDon { get; set; }
        public Guid IdPhieuKham { get; set; }

        public bool? TrangThai { get; set; }

        [ForeignKey("IdHoaDon")]
        public virtual HoaDon? Bill { get; set; }
        [ForeignKey("IdPhieuKham")]
        public virtual PhieuKham? MedicalBills { get; set; }
    }
}
