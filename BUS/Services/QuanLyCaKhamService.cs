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
    public class QuanLyCaKhamService : IQuanLyCaKhamService
    {
        CaKhamRepository _caKhamRepository = new CaKhamRepository();
        public bool Create(CaKham caKham)
        {
            _caKhamRepository.Update(caKham);
            return true;
        }

        public CaKham FindById(Guid id)
        {
            return _caKhamRepository.FindById(id);
        }

        public List<CaKham> GetCaKhams()
        {
            return _caKhamRepository.GetCaKhams().ToList();
        }

        public bool Update(CaKham caKham)
        {
            _caKhamRepository.Update(caKham);
            return true;
        }
    }
}
