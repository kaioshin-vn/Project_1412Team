using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IDanhGiaRepository
    {
        public List<DanhGia> GetDanhGias();
        public bool Create(DanhGia danhGia);
        public bool Update(DanhGia danhGia);
        public DanhGia FindById(Guid id);
    }
}
