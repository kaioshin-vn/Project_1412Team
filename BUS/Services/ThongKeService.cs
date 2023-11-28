using A_DAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class ThongKeService
    {
        ThongKeRepo _repo = new ThongKeRepo();
        public ThongKeService() { }
        public List<ThongKe> GetThongKes()
        {
            return _repo.GetThongKe().ToList();
        }
        public bool AddThongKe(bool loaiTK, string ghiChu, Guid idHoaDon, Guid idLuong)
        {
            var thongke = new ThongKe()
            {
                LoaiThongKe = loaiTK,
                GhiChu = ghiChu,
                IdHoaDon = idHoaDon,
                IdLuong = idLuong
            };
            return _repo.AddThongKe(thongke);
        }
        public bool UpdateThongKe(Guid idTK, bool loaiTK, string ghiChu, Guid idHoaDon, Guid idLuong)
        {
            var thongke = new ThongKe()
            {
                IdThongKe = idTK,
                LoaiThongKe = loaiTK,
                GhiChu = ghiChu,
                IdHoaDon = idHoaDon,
                IdLuong = idLuong
            };
            return _repo.UpdateThongKe(thongke);
        }
    }
}
