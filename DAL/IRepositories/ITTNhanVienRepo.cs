using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface ITTNhanVienRepo
    {
        List<TrangThaiNhanVien> GetTTNhanVien();
        TrangThaiNhanVien FindTTNhanVien(int id);
        bool AddTTNhanVien(TrangThaiNhanVien trangThaiNhanVien);
        bool UpdateTTNhanVien(TrangThaiNhanVien trangThaiNhanVien);
    }
}
