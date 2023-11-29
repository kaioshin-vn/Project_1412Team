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
        public DichVuService() {
            _repo = new DichVuRepository();
        }
        public List<DichVu> GetAllDichVu(string search)
        {
            if (search == null)
            {
                return _repo.GetAllDichVu();
            }
            return _repo.GetAllDichVu().Where(x => x.Ten.Trim().ToLower().Contains(search)).ToList();
        }
        public bool AddDichVu(DichVu dv)
        {
            if (_repo.AddDichVu(dv))
            {
                return true;
            }
            return false;
        }

        public bool UpdateDichVu(DichVu dv)
        {
            
            if (_repo.UpdateDichVu(dv) == true)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDichVu(DichVu dv)
        {
            var clone = _repo.GetAllDichVu().FirstOrDefault(x => x.IdDichVu == dv.IdDichVu);
            if (clone !=null)
            {
                if (_repo.DeleteDichVu(clone) == true)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
