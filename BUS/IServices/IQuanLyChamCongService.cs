using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface IQuanLyChamCongService
    {
        public List<ChamCong> GetChamCongs();
        public bool Create(ChamCong chamCong);
        public bool Update(ChamCong chamCong);
        public ChamCong FindById(Guid id);
    }
}
