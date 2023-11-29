using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IHoaDonChiTietService
    {
        public List<HoaDonChiTiet> GetAllHDCT();
        public HoaDonChiTiet FindHoaDonCT(Guid id);
        public bool AddHDCT(HoaDonChiTiet hdct);
        public bool UpdateHDCT(HoaDonChiTiet hdct);
    }
}
