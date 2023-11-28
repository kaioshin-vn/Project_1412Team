using A_DAL.IRepositories;
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
    public class KhachHangService : IKhachHangService
    {
        private readonly KhachHangRepository _repo;
        public List<KhachHang> GetAllKhachHang(string search)
        {
            if (search == null)
            {
                 return _repo.GetAllKhachHang().ToList();
            }
            return _repo.GetAllKhachHang().Where(x => x.Ten.Trim().ToLower().Contains(search) || x.SoDienThoai.Trim().Contains(search)).ToList();
        }
        public KhachHang FindKhachHang(dynamic id)
        {
            return _repo.GetAllKhachHang().FirstOrDefault(x => x.IdKhachHang == id);
        }
        public bool AddKhachHang(KhachHang kh)
        {
            if (_repo.AddKhachHang(kh) == true)
            {
                return true;
            }
            return false;

        }
        public bool UpdateKhachHang(KhachHang kh)
        {
            var clone = _repo.GetAllKhachHang().FirstOrDefault(x => x.IdKhachHang == kh.IdKhachHang);
            clone.Ten = kh.Ten;
            clone.GioiTinh = kh.GioiTinh;
            clone.NgaySinh = kh.NgaySinh;
            clone.DiaChi = kh.DiaChi;
            clone.SoDienThoai = kh.SoDienThoai;
            clone.HienThi = kh.HienThi;
            if (_repo.UpdateKhachHang(clone)==true)
            {
                return true;
            }
            return false;
        }

        public bool DeleteKhachHang(KhachHang kh )
        {
            var clone = _repo.GetAllKhachHang().FirstOrDefault(x => x.IdKhachHang == kh.IdKhachHang);
            if(_repo.DeleteKhachHang(clone) == true)
            {
                return true;
            }
            return false;
        }
    }
}
