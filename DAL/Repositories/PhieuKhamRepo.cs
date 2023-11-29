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
    public class PhieuKhamRepo : IPhieuKhamRepo
    {
        private readonly MyDbContext _dbContext;
        public PhieuKhamRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddPhieuKham(PhieuKham pk)
        {
  
            _dbContext.PhieuKhams.Add(pk);
            _dbContext.SaveChanges();
            return true;
        }

        public PhieuKham FindPhieuKhamId(Guid id)
        {
            return _dbContext.PhieuKhams.Find(id);
        }

        public List<PhieuKham> GetAllPhieuKham()
        {
            return _dbContext.PhieuKhams.ToList();
        }

        public bool UpdatePhieuKham(PhieuKham pk)
        {
            _dbContext.PhieuKhams.Update(pk);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
