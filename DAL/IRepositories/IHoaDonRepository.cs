using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IHoaDonRepository
    {
        public List<HoaDon> GetAllHoaDon();
        public bool AddHoaDon(HoaDon hd);
        public bool UpdateHoaDon(HoaDon hd);
        public bool DeleteHoaDon(HoaDon hd);
    }
}
