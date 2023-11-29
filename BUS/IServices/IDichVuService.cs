using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IDichVuService
    {
        public List<DichVu> GetAllDichVu(string search);
        public bool AddDichVu(DichVu dv);
        public bool UpdateDichVu(DichVu dv);
        public bool DeleteDichVu(DichVu dv);
    }
}
