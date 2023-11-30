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
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly MyDbContext _dbContext;
        public KhachHangRepository() { _dbContext = new MyDbContext(); }
        public List<KhachHang> GetAllKhachHang()
        {
            return _dbContext.KhachHangs.Where(a => a.HienThi == true).ToList();
        }
        public bool AddKhachHang(KhachHang kh)
        {
            _dbContext.KhachHangs.Add(kh);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateKhachHang(KhachHang kh)
        {
            _dbContext.KhachHangs.Update(kh);
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteKhachHang(KhachHang kh)
        {
            _dbContext.KhachHangs.Remove(kh);
            _dbContext.SaveChanges();
            return true;
        }


    }
}
