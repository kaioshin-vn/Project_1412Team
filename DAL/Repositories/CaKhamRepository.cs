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
    public class CaKhamRepository : ICaKhamRepository
    {
        MyDbContext dbcontext = new MyDbContext();

        public CaKhamRepository()
        {
        }
        public bool Create(CaKham caKham)
        {
            dbcontext.CaKhams.Add(caKham);
            return dbcontext.SaveChanges() > 0;
        }

        public CaKham FindById(Guid id)
        {
            return dbcontext.CaKhams.Find(id);
        }

        public List<CaKham> GetCaKhams()
        {
            return dbcontext.CaKhams.ToList();
        }

        public bool Update(CaKham caKham)
        {
            dbcontext.CaKhams.Update(caKham);
            return dbcontext.SaveChanges() > 0;

        }
    }
}
