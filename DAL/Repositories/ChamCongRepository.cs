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
    public class ChamCongRepository : IChamCongRepository
    {
        MyDbContext dbcontext = new MyDbContext();

        public ChamCongRepository()
        {
        }
        public bool Create(ChamCong chamCong)
        {
            dbcontext.ChamCongs.Add(chamCong);
            return dbcontext.SaveChanges() > 0;
        }

        public ChamCong FindById(Guid id)
        {
            return dbcontext.ChamCongs.Find(id);
        }

        public List<ChamCong> GetChamCongs()
        {
            return dbcontext.ChamCongs.ToList();
        }

        public bool Update(ChamCong chamCong)
        {
            dbcontext.ChamCongs.Update(chamCong);
            return dbcontext.SaveChanges() > 0;
        }
    }
}
