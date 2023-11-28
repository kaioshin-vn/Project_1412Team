using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IHoaDonChiTietRepo
    {
        public List<HoaDonChiTiet> GetAllHDCT();
        public bool AddHDCT(HoaDonChiTiet hdct);
        public bool UpdateHDCT(HoaDonChiTiet hdct);
    }
}
