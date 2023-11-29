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
    public class HoaDonChiTietRepo : IHoaDonChiTietRepo
    {
        private readonly MyDbContext   _dbContext;
        public HoaDonChiTietRepo()
        {
            _dbContext = new MyDbContext();
        }
        public List<HoaDonChiTiet> GetAllHDCT()
        {
            return _dbContext.HoaDonChiTiets.ToList();
        }
        public bool AddHDCT(HoaDonChiTiet hdct)
        {
            _dbContext.HoaDonChiTiets.Add(hdct);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateHDCT(HoaDonChiTiet hdct)
        {
            _dbContext.HoaDonChiTiets.Update(hdct);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
