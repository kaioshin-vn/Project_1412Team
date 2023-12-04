using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class DichVuRepository : IDichVuRepository
    {
        private readonly MyDbContext _dbContext;
        public DichVuRepository() 
        {
            _dbContext = new MyDbContext();
        }
      
        public List<DichVu> GetAllDichVu()
        {
            return _dbContext.DichVus.Where( a => a.HienThi == true).ToList();
        }

        public List<DichVu> GetTatCaDichVu()
        {
            return _dbContext.DichVus.ToList();
        }

        public bool AddDichVu(DichVu dv)
        {
            _dbContext.DichVus.Add(dv);
            _dbContext.SaveChanges();
            return true;
        }
        
        public bool UpdateDichVu(DichVu dv)
        {
            _dbContext.DichVus.Update(dv);
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteDichVu(DichVu dv)
        {
            _dbContext.DichVus.Remove(dv);
            _dbContext.SaveChanges() ;
            return true;
        }

    }
}
