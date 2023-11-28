using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class BacSiRepository : IBacSiRepository
    {
        MyDbContext dbcontext = new MyDbContext();

        public BacSiRepository()
        {
            GetBacSis();
        }
        public bool Create(BacSi bs)
        {
            dbcontext.BacSis.Add(bs);
            return dbcontext.SaveChanges() > 0;
        }

        public BacSi FindById(Guid id)
        {
            return dbcontext.BacSis.Find(id);
        }

        public List<BacSi> GetBacSis()
        {
            return dbcontext.BacSis.ToList();
        }

        public bool Update(BacSi bs)
        {
            dbcontext.BacSis.Update(bs);
            return dbcontext.SaveChanges() > 0;
        }
    }
}
