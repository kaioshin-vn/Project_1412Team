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
            var thongBao = _dbContext.ThongBaos.FirstOrDefault(x => x.IdThongBao == tb.IdThongBao);

            thongBao.TinNhan = tb.TinNhan;
            thongBao.TrangThai = tb.TrangThai;
            thongBao.ChapNhan = tb.ChapNhan;

            _dbContext.ThongBaos.Update(thongBao);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
