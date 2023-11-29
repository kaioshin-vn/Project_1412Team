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
    public class ChamCongService : IQuanLyChamCongService
    {
        ChamCongRepository _chamCongRepository = new ChamCongRepository();

        public bool Create(ChamCong chamCong)
        {
            _chamCongRepository.Create(chamCong);
            return true;
        }

        public ChamCong FindById(Guid id)
        {
            return _chamCongRepository.FindById(id);
        }

        public List<ChamCong> GetChamCongs()
        {
            return _chamCongRepository.GetChamCongs().ToList();
        }

        public bool Update(ChamCong chamCong)
        {
            _chamCongRepository.Update(chamCong);
            return true;
        }
    }
}
