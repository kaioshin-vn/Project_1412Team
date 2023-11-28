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
    public class DanhGiaRepository : IDanhGiaRepository
    {
        MyDbContext dbcontext = new MyDbContext();

        public DanhGiaRepository()
        {
            GetDanhGias();
        }
        public bool Create(DanhGia danhGia)
        {
            dbcontext.DanhGias.Add(danhGia);
            return dbcontext.SaveChanges() > 0;
        }

        public DanhGia FindById(Guid id)
        {
            return dbcontext.DanhGias.Find(id);
        }

        public List<DanhGia> GetDanhGias()
        {
            return dbcontext.DanhGias.ToList();
        }

        public bool Update(DanhGia danhGia)
        {
            dbcontext.DanhGias.Update(danhGia);
            return dbcontext.SaveChanges() > 0;
        }
    }
}
