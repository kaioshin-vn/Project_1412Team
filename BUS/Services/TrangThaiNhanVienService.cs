using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class TrangThaiNhanVienService
    {
        MyDbContext myDbContext = new MyDbContext();

        public bool UpdateTrangThaiNhanVien (TrangThaiNhanVien trangThaiNhanVien)
        {
            myDbContext.TrangThaiNhanViens.Update(trangThaiNhanVien); 
            return true;
        }
        public List< TrangThaiNhanVien > GetAllTrangThaiNhanVien()
        {
            return myDbContext.TrangThaiNhanViens.ToList();
        }
    }
}
