using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface IQuanLyDanhGiaService
    {
        public List<DanhGia> GetDanhGias();
        public bool Create(DanhGia danhGia);
        public bool Update(DanhGia danhGia);
        public DanhGia FindById(Guid id);
    }
}
