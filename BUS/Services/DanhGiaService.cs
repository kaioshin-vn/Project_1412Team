using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class DanhGiaService : IQuanLyDanhGiaService
    {
        DanhGiaRepository _danhGiaRepository = new DanhGiaRepository();
        public bool Create(DanhGia danhGia)
        {
            _danhGiaRepository.Create(danhGia);
            return true;
        }

        public DanhGia FindById(Guid id)
        {
            return _danhGiaRepository.FindById(id);
        }

        public List<DanhGia> GetDanhGias()
        {
            return _danhGiaRepository.GetDanhGias().ToList();
        }

        public bool Update(DanhGia danhGia)
        {
            _danhGiaRepository.Update(danhGia);
            return true;
        }
    }
}
