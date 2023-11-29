using A_DAL.Repositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class YTaService
    {
        MyDbContext _dbContext = new MyDbContext();

        public bool CreateYTa(YTa yTa)
        {
            _dbContext.YTas.Add(yTa);
            return true;
        }

        public bool UpdateYTa(YTa yTa)
        {
            _dbContext.YTas.Update(yTa);
            return _dbContext.SaveChanges() > 0;
        }
        public YTa FindYTa(Guid id)
        {
            return _dbContext.YTas.FirstOrDefault(a => a.IdYTa == id);
        }
        public List<YTa> GetAllYTa()
        {
            return _dbContext.YTas.ToList();
        }
    }
}
