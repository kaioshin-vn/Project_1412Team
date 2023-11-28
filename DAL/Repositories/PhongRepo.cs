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
    public class PhongRepo : IPhongRepo
    {
        private readonly MyDbContext _dbContext;
        public PhongRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddPhong(Phong p)
        {
            _dbContext.Phongs.Add(p);
            _dbContext.SaveChanges();
            return true;
        }

        public Phong FindPhongId(Guid id)
        {
            return _dbContext.Phongs.Find(id);
        }

        public List<Phong> GetAllPhong()
        {
            return _dbContext.Phongs.ToList();
        }

        public bool UpdatePhong(Phong p)
        {
            var phong = _dbContext.Phongs.FirstOrDefault(x => x.Id == p.Id);

            phong.Ten = p.Ten;

            _dbContext.Phongs.Update(phong);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
