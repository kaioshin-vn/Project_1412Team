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
    public class ThongBaoRepo : IThongBaoRepo
    {
        private readonly MyDbContext _dbContext;
        public ThongBaoRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddThongBao(ThongBao tb)
        {
            if(tb == null) return false;
            _dbContext.ThongBaos.Add(tb);
            _dbContext.SaveChanges();
            return true;
        }

        public ThongBao FindThongBaoId(Guid id)
        {
            return _dbContext.ThongBaos.Find(id);
        }

        public List<ThongBao> GetAllThongBao()
        {
            return _dbContext.ThongBaos.ToList();
        }

        public bool UpdateThongBao(ThongBao tb)
        { 
            _dbContext.ThongBaos.Update(tb);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
