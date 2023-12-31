﻿using A_DAL.IRepositories;
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
    public class NhanVienSer : INhanVienSer
    {
        private readonly NhanVienRepo _nvRepo;
        public NhanVienSer()
        {
            _nvRepo = new NhanVienRepo();
        }
        public bool AddNhanVien(NhanVien nv)
        {
            return _nvRepo.AddNhanVien(nv);
        }

        public NhanVien FindNhanVien(Guid id)
        {
            return _nvRepo.FindNhanVienId(id);
        }

        public List<NhanVien> GetAllNhanVien(string search)
        {
            if(search == null)
            {
                return _nvRepo.GetAllNhanVien().ToList();
            }
            return _nvRepo.GetAllNhanVien().Where(x => x.Ten.Trim().ToLower().Contains(search) || x.SoDienThoai.Trim().Contains(search)).ToList();
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _nvRepo.GetAllNhanVien();
        }

        public List<NhanVien> GetTatCaVien()
        {
            return _nvRepo.GetTatCaNhanVien();
        }

        public bool UpdateNhanVien(NhanVien nv)
        {

            if (_nvRepo.UpdateNhanVien(nv) == true)
            {
                return true;
            }
            return false;
        }
    }
}
