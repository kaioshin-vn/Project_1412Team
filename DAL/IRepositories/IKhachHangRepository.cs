using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IKhachHangRepository
    {
        public List<KhachHang> GetAllKhachHang();
        public bool AddKhachHang(KhachHang kh);
        public bool UpdateKhachHang(KhachHang kh);
        public bool DeleteKhachHang(KhachHang kh);
    }
}
