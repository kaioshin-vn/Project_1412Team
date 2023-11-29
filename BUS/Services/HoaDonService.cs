using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class HoaDonService : IHoaDonService
    {
        private readonly HoaDonRepository _repo = new HoaDonRepository();
        public List<HoaDon> GetAllHoaDon()
        {
            return _repo.GetAllHoaDon();
        }

        public HoaDon FindHoaDon(Guid id)
        {
            return _repo.GetAllHoaDon().FirstOrDefault(x => x.IdHoaDon == id);
        }

        public bool AddHoaDon(HoaDon hd)
        {
            if (_repo.AddHoaDon(hd)==true)
            {
                return true;
            }
            return false;
        }

     
       
        public bool UpdateHoaDon(HoaDon hd)
        {
            if (_repo.UpdateHoaDon(hd) == true)
            {
                return true;
            }
            return false;
        }

        public bool DeleteHoaDon(HoaDon hd)
        {
            throw new NotImplementedException();
        }
    }
}
