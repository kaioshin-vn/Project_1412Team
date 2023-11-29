using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface ICaKhamRepository
    {
        public List<CaKham> GetCaKhams();
        public bool Create(CaKham caKham);
        public bool Update(CaKham caKham);
        public CaKham FindById(Guid id);
    }
}
