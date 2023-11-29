using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class ThongKeService
    {
        MyDbContext _dbContext = new MyDbContext();

        public bool AddThongKe(ThongKe thongKe)
        {
            _dbContext.ThongKes.Add(thongKe);
            return _dbContext.SaveChanges()    > 0;
        }
        public bool UpdateThongKe(ThongKe thongKe)
        {
            _dbContext.ThongKes.Update(thongKe);
            return _dbContext.SaveChanges()>0;
        }
        public ThongKe FindThongKe(Guid id)
        {
            return _dbContext.ThongKes.FirstOrDefault(a  => a.IdThongKe == id);
        }
        public List<ThongKe> GetAllThongKe()
        {
            return _dbContext.ThongKes.ToList();
        }
    }
}
