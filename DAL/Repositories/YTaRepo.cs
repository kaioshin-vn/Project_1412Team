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
    public class YTaRepo : IYTaRepo
    {
        MyDbContext _context = new MyDbContext();

        public YTaRepo()
        {
        }

        public YTaRepo(MyDbContext context)
        {
            _context = context;
        }

        public bool AddYTa(YTa yTa)
        {
            try
            {
                _context.YTas.Add(yTa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public YTa FindYTa(Guid id)
        {
            return _context.YTas.Find(id);
        }

        public List<YTa> GetYTa()
        {
            return _context.YTas.ToList();
        }

        public bool UpdateYTa(YTa yTa)
        {
            try
            {
                var updateYTa = FindYTa(yTa.IdYTa);
                updateYTa.DiaChi = yTa.DiaChi;
                updateYTa.NgaySinh = yTa.NgaySinh;
                updateYTa.GioiTinh = yTa.GioiTinh;
                updateYTa.HienThi = yTa.HienThi;
                updateYTa.NhanVien = yTa.NhanVien;
                updateYTa.PhieuKham = yTa.PhieuKham;
                _context.YTas.Update(yTa);
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
