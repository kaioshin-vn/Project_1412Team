using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IDichVuRepository
    {
        public List<DichVu> GetAllDichVu();
        public bool AddDichVu(DichVu dv);
        public bool UpdateDichVu(DichVu dv);
        public bool DeleteDichVu(DichVu dv);
    }
}
