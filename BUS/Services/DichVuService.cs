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
    public class DichVuService : IDichVuService
    {
        private readonly DichVuRepository _repo;
        public DichVuService() { }
        public List<DichVu> GetAllDichVu(string search)
        {
            if (search == null)
            {
                return _repo.GetAllDichVu();
            }
            return _repo.GetAllDichVu().Where(x => x.Ten.Trim().ToLower().Contains(search)).ToList();
        }
        public bool AdđichVu(DichVu dv)
        {
            if (_repo.AddDichVu(dv) != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateDichVu(DichVu dv)
        {
            var clone = _repo.GetAllDichVu().FirstOrDefault(x => x.IdDichVu == dv.IdDichVu);
            clone.Ten = dv.Ten;
            clone.MoTa = dv.MoTa;
            clone.Gia = dv.Gia;
            clone.HienThi = dv.HienThi;
            if (_repo.UpdateDichVu(clone) == true)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDichVu(DichVu dv)
        {
            var clone = _repo.GetAllDichVu().FirstOrDefault(x => x.IdDichVu == dv.IdDichVu);
            if (_repo.DeleteDichVu(clone) == true)
            {
                return true;
            }
            return false;

        }
    }
}
