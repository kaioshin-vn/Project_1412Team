using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface ILichSuKhamRepository
    {
        public List<LichSuKham> GetAllLichSuKham();
        public bool AddlichSuKham(LichSuKham lsk);
        public bool UpdatelichSuKham(LichSuKham lsk);
    }
}
