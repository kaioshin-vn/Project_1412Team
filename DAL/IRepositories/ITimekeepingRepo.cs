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
        public List<TimeKeeping> GetAll();
        public bool AddNVTime(TimeKeeping nvt);
        public bool UpdateNVTime(TimeKeeping nvt);
        public bool DeleteNVTime(TimeKeeping nvt);
    }
}
