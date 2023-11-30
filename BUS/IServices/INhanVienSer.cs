using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface INhanVienSer
    {
        bool AddNhanVien(NhanVien nv);
        bool UpdateNhanVien(NhanVien nv);
        List<NhanVien> GetAllNhanVien(string search);
        NhanVien FindNhanVien(Guid id);
    }
}
