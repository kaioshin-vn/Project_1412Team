using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface INhanVienRepo
    {
        bool AddNhanVien(NhanVien nv);
        bool UpdateNhanVien(NhanVien nv);
        List<NhanVien> GetAllNhanVien();
        NhanVien FindNhanVienId(Guid id);
    }
}
