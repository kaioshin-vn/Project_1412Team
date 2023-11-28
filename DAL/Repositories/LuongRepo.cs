using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class LuongRepo : ILuongRepo
    {
        private readonly MyDbContext _dbContext;
        public LuongRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddLuong(Luong l)
        {
            _dbContext.Luongs.Add(l);
            _dbContext.SaveChanges();
            return true;
        }

        public Luong FindLuongId(Guid id)
        {
            return _dbContext.Luongs.Find(id);
        }

        public List<Luong> GetAllLuong()
        {
            return _dbContext.Luongs.ToList();
        }

        public bool UpdateLuong(Luong l)
        {
            var luong = _dbContext.Luongs.FirstOrDefault(x => x.IdLuong == l.IdLuong);

            luong.TrangThai = l.TrangThai;
            luong.Thuong = l.Thuong;
            luong.Thang = l.Thang;
            luong.SoCong = l.SoCong;

            _dbContext.Luongs.Update(luong);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
