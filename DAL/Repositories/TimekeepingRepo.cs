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
    public class TimekeepingRepo : ITimekeepingRepo
    {
        private MyDbContext _dbContext;

        public TimekeepingRepo()
        {
            _dbContext = new MyDbContext();
        }

        public List<ChamCong> GetAll()
        {
            return _dbContext.TimeKeepings.ToList();
        }
        public bool AddNVTime(ChamCong nvt)
        {
            _dbContext.Add(nvt);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateNVTime(ChamCong nvt)
        {
            _dbContext.Update(nvt);
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteNVTime(ChamCong nvt)
        {
            _dbContext.Remove(nvt);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
