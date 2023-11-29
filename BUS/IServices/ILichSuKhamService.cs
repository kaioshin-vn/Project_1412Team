using DAL.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface ILichSuKhamService
    {
        public List<LichSuKham> GetAllLichSuKham(string search);
        public LichSuKham FindLichSuKham(Guid id);
        public bool AddlichSuKham(LichSuKham lsk);
        public bool UpdatelichSuKham(LichSuKham lsk);
    }
}
