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
       
        public List<TimeKeeping> GetAll(string search);
        public string AddNVTime(TimeKeeping nvt);
        public string UpdateNVTime(TimeKeeping nvt);
        public string DeleteNVTime(TimeKeeping nvt);
    }
}
