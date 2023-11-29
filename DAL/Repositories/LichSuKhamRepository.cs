using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class LichSuKhamRepository : ILichSuKhamRepository
    {
        private readonly MyDbContext _dbContext;
        public LichSuKhamRepository()
        {
            _dbContext = new MyDbContext();
        }
        public List<LichSuKham> GetAllLichSuKham()
        {
            return _dbContext.lichSuKhams.ToList();
        }
        public bool AddlichSuKham(LichSuKham lsk)
        {
            _dbContext.lichSuKhams.Add(lsk);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdatelichSuKham(LichSuKham lsk)
        {
            _dbContext.lichSuKhams.Update(lsk);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
