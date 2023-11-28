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
    public class LichSuKhamService : ILichSuKhamService
    {
        private readonly LichSuKhamRepository _repo;
        public List<LichSuKham> GetAllLichSuKham(string search)
        {
            if (search == null)
            {
                return _repo.GetAllLichSuKham();
            }
            return _repo.GetAllLichSuKham().Where(x => x.KetQua.Contains(search)).ToList();
        }
        public LichSuKham FindLichSuKham(Guid id)
        {
            return _repo.GetAllLichSuKham().FirstOrDefault(x => x.IdPhieuKham == id);
        }

        public bool AddlichSuKham(LichSuKham lsk)
        {
            if (_repo.AddlichSuKham(lsk) == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdatelichSuKham(LichSuKham lsk)
        {
            var clone = _repo.GetAllLichSuKham().FirstOrDefault(x => x.IdPhieuKham == lsk.IdPhieuKham);
            clone.KetQua = lsk.KetQua;
            clone.GhiChu = lsk.GhiChu;
            if (_repo.UpdatelichSuKham(clone) == true)
            {
                return true;
            }
            return false;
        }
    }
}
