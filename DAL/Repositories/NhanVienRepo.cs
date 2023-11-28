using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class NhanVienRepo : INhanVienRepo
    {
        private readonly MyDbContext _dbContext;
        public NhanVienRepo()
        {
            _dbContext = new MyDbContext();
        }
        public bool AddNhanVien(NhanVien nv)
        {
            _dbContext.NhanViens.Add(nv);
            _dbContext.SaveChanges();
            return true;
        }

        public NhanVien FindNhanVienId(Guid id)
        {
            return _dbContext.NhanViens.Find(id);
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _dbContext.NhanViens.ToList();
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            var nhanVien = _dbContext.NhanViens.FirstOrDefault(x => x.IdNhanVien == nv.IdNhanVien);

            nhanVien.SoDienThoai = nv.SoDienThoai;
            nhanVien.Ten = nv.Ten;
            nhanVien.TrangThai = nv.TrangThai;
            nhanVien.MatKhau = nv.MatKhau;

            _dbContext.NhanViens.Update(nhanVien);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
