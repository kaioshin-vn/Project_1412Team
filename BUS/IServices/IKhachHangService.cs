using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IKhachHangService
    {
        public List<KhachHang> GetAllKhachHang(string search);
        public KhachHang FindKhachHang(dynamic id);
        public bool AddKhachHang(KhachHang kh);
        public bool UpdateKhachHang(KhachHang kh);
        public bool DeleteKhachHang(KhachHang kh);
    }
}
