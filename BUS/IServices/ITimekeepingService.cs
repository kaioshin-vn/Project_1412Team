using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface ITimekeepingService
    {
       
        public List<ChamCong> GetAll(string search);
        public string AddNVTime(ChamCong nvt);
        public string UpdateNVTime(ChamCong nvt);
        public string DeleteNVTime(ChamCong nvt);
    }
}
