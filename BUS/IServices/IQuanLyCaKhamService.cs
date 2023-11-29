using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface IQuanLyCaKhamService
    {
        public List<CaKham> GetCaKhams();
        public bool Create(CaKham caKham);
        public bool Update(CaKham caKham);
        public CaKham FindById(Guid id);
    }
}
