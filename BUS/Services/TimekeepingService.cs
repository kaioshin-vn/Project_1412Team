using A_DAL.Migrations;
using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class TimekeepingService : ITimekeepingService
    {
        private TimekeepingRepo _repos;
        public TimekeepingService()
        {
            _repos = new TimekeepingRepo();
        }
        public List<ChamCong> GetAll(string search)
        {
            if(search == null)
            {
                return _repos.GetAll();
            }
            return _repos.GetAll().Where(x => x.NameNV.Trim().ToLower().Contains(search)).ToList();
        }

        public string AddNVTime(ChamCong nvt)
        {
            if (_repos.AddNVTime(nvt) == true)
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string UpdateNVTime(ChamCong nvt)
        {
            return "Để sau";
        }
        public string DeleteNVTime(ChamCong nvt)
        {
            var clone = _repos.GetAll().FirstOrDefault(x => x.Id == nvt.Id);
            if (_repos.DeleteNVTime(clone) == true)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

       

       
    }
}
