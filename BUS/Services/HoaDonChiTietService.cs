using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {

        private readonly HoaDonChiTietRepo _repo = new HoaDonChiTietRepo();
        public List<HoaDonChiTiet> GetAllHDCT()
        {
            return _repo.GetAllHDCT();
        }
        public HoaDonChiTiet FindHoaHoaDon(Guid id)
        {
            return _repo.GetAllHDCT().FirstOrDefault(x => x.IdHoaDon == id);
        }

        public HoaDonChiTiet FindHoaPhieuKham(Guid id)
        {
            return _repo.GetAllHDCT().FirstOrDefault(x => x.IdPhieuKham == id);
        }

        public bool AddHDCT(HoaDonChiTiet hdct)
        {
            if (_repo.AddHDCT(hdct) == true)
            {
                return true;
            }
            return false;
        }


        public bool UpdateHDCT(HoaDonChiTiet hdct)
        {
            if (_repo.UpdateHDCT(hdct) == true)
            {
                return true;
            }
            return false;
        }

        public HoaDonChiTiet FindHoaDonCT(Guid id)
        {
            return _repo.GetAllHDCT().FirstOrDefault(x => x.IdHoaDonCT == id);
        }
    }
 }
