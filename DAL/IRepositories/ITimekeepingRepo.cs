using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface ITimekeepingRepo
    {
        public List<ChamCong> GetAll();
        public bool AddNVTime(ChamCong nvt);
        public bool UpdateNVTime(ChamCong nvt);
        public bool DeleteNVTime(ChamCong nvt);
    }
}
