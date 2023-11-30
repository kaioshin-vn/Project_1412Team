using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class TTNhanVienRepo : ITTNhanVienRepo
    {
        MyDbContext _context = new MyDbContext();

        public TTNhanVienRepo()
        {
        }

        public TTNhanVienRepo(MyDbContext context)
        {
            _context = context;
        }

        public bool AddTTNhanVien(TrangThaiNhanVien trangThaiNhanVien)
        {
            try
            {
                _context.TrangThaiNhanViens.Add(trangThaiNhanVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TrangThaiNhanVien FindTTNhanVien(int id)
        {
            return _context.TrangThaiNhanViens.Find(id);
        }

        public List<TrangThaiNhanVien> GetTTNhanVien()
        {
            return _context.TrangThaiNhanViens.ToList();
        }

        public bool UpdateTTNhanVien(TrangThaiNhanVien trangThaiNhanVien)
        {
            try
            {
                var updateTTNhanVien = FindTTNhanVien(trangThaiNhanVien.IdNgay);
                updateTTNhanVien.TrangThai = trangThaiNhanVien.TrangThai;
                updateTTNhanVien.IdCaKham = trangThaiNhanVien.IdCaKham;
                updateTTNhanVien.IdNhanVien = trangThaiNhanVien.IdNhanVien;
                updateTTNhanVien.Ngay = trangThaiNhanVien.Ngay;
                updateTTNhanVien.PhieuKham = trangThaiNhanVien.PhieuKham;
                updateTTNhanVien.NhanVien = trangThaiNhanVien.NhanVien;
                //updateTTNhanVien.CaKham = trangThaiNhanVien.CaKham;
                _context.TrangThaiNhanViens.Update(updateTTNhanVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
