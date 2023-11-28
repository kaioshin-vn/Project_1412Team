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
    public class PhongSer : IPhongSer
    {
        private readonly IPhongRepo _phongRepo;
        public PhongSer()
        {
            _phongRepo = new PhongRepo();
        }
        public bool AddPhong(Phong p)
        {
            return _phongRepo.AddPhong(p);
        }

        public Phong FindPhong(Guid id)
        {
            return _phongRepo.FindPhongId(id);
        }

        public List<Phong> GetAllPhong()
        {
            return _phongRepo.GetAllPhong().ToList();
        }

        public bool UpdatePhong(Phong p)
        {
            return _phongRepo.UpdatePhong(p);
        }
    }
}
