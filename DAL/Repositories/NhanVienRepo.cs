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
    public class NhanVienRepo : INhanVienRepo
    {
        private readonly MyDbContext _dbContext;
        public NhanVienRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddNhanVien(NhanVien nv)
        {
            _dbContext.NhanViens.Add(nv);
            _dbContext.SaveChanges();
            return true;
        }

        public NhanVien FindNhanVienId(Guid id)
        {
            return _dbContext.NhanViens.FirstOrDefault( a => a.IdNhanVien == id);
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _dbContext.NhanViens.Where(a => a.HienThi == true).ToList();
        }

        public List<NhanVien> GetTatCaNhanVien()
        {
            return _dbContext.NhanViens.ToList();
        }

        public bool UpdateNhanVien(NhanVien nv)
        {

            _dbContext.NhanViens.Update(nv);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
