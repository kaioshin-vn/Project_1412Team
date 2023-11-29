using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IHoaDonService
    {
        public List<HoaDon> GetAllHoaDon();
        public HoaDon FindHoaDon(Guid id);
        public bool AddHoaDon(HoaDon hd);
        public bool UpdateHoaDon(HoaDon hd);
        public bool DeleteHoaDon(HoaDon hd);
    }
}
