using A_DAL.IRepositories;
using DAL.Models;
using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class ThongKeRepo : IThongKeRepo
    {
        MyDbContext _context = new MyDbContext();
        public ThongKeRepo() { }

        public ThongKeRepo(MyDbContext context)
        {
            _context = context;
        }

        public bool AddThongKe(ThongKe thongKe)
        {
            try
            {
                _context.ThongKes.Add(thongKe);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public ThongKe FindThongKe(Guid id)
        {
            return _context.ThongKes.Find(id);
        }

        public List<ThongKe> GetThongKe()
        {
            return _context.ThongKes.ToList();
        }

        public bool UpdateThongKe(ThongKe thongKe)
        {
            try
            {
                var updateThongKe = FindThongKe(thongKe.IdThongKe);
                updateThongKe.LoaiThongKe = thongKe.LoaiThongKe;
                updateThongKe.GhiChu = thongKe.GhiChu;
                updateThongKe.IdHoaDon = thongKe.IdHoaDon;
                updateThongKe.IdLuong = thongKe.IdLuong;
                updateThongKe.HoaDon = thongKe.HoaDon;
                updateThongKe.Luong = thongKe.Luong;
                _context.ThongKes.Update(updateThongKe);
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
