using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IChamCongRepository
    {
        public List<ChamCong> GetChamCongs();
        public bool Create(ChamCong chamCong);
        public bool Update(ChamCong chamCong);
        public ChamCong FindById(Guid id);
    }
}
