using A_DAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class TTNhanVienSer
    {
        TTNhanVienRepo _repo = new TTNhanVienRepo();

        public TTNhanVienSer()
        {
        }

        public TTNhanVienSer(TTNhanVienRepo repo)
        {
            _repo = repo;
        }
        public List<TrangThaiNhanVien> GetTTNhanVien()
        {
            return _repo.GetTTNhanVien().ToList();
        }
        public bool AddTTNhanVien(TrangThaiNhanVien trangThaiNhanVien)
        {
            return _repo.AddTTNhanVien(trangThaiNhanVien);
        }
        public bool UpdateTTNhanVien(TrangThaiNhanVien trangThaiNhanVien)
        {
            return _repo.UpdateTTNhanVien(trangThaiNhanVien);
        }
    }
}
