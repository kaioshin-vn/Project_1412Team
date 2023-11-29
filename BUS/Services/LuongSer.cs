using A_DAL.IRepositories;
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
    public class LuongSer : ILuongSer
    {
        private readonly ILuongRepo _luongRepo = new LuongRepo();
        public LuongSer()
        {
            _luongRepo = new LuongRepo();
        }
        public bool AddLuong(Luong l)
        {
            _luongRepo.AddLuong(l);
            return true;
        }

        public Luong FindLuong(Guid id)
        {
            return _luongRepo.FindLuongId(id);
        }

        public List<Luong> GetAllLuong()
        {
            return _luongRepo.GetAllLuong().ToList();
        }

        public bool UpdateLuong(Luong l)
        {
            _luongRepo.UpdateLuong(l);
            return true;
        }
    }
}
