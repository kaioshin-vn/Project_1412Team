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
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly MyDbContext _dbContext;
        public HoaDonRepository()
        {
            _dbContext = new MyDbContext();
        }

        public List<HoaDon> GetAllHoaDon()
        {
            return _dbContext.HoaDons.ToList();
        }
        public bool AddHoaDon(HoaDon hd)
        {
            _dbContext.HoaDons.Add(hd);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateHoaDon(HoaDon hd)
        {
            _dbContext.HoaDons.Update(hd);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteHoaDon(HoaDon hd)
        {
            _dbContext.HoaDons.Remove(hd);
            _dbContext.SaveChanges();
            return true;
        }
    }

    }

