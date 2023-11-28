using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Models;

namespace DAL.IRepositories
{
    public interface ICustomerRepo
    {
        public List<KhachHang> GetAll();
        public bool AddLichKham();
        public bool UpdateLichKham();
        public bool RemoveLichKham();
    }
}
