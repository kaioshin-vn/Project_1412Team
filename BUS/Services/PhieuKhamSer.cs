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
    public class PhieuKhamSer : IPhieuKhamSer
    {
        private readonly IPhieuKhamRepo _pkRepo;
        public PhieuKhamSer()
        {
            _pkRepo = new PhieuKhamRepo();
        }
        public bool AddPhieuKham(PhieuKham pk)
        {
            return _pkRepo.AddPhieuKham(pk);
        }

        public PhieuKham FindPhieuKham(Guid id)
        {
            return _pkRepo.FindPhieuKhamId(id);
        }

        public List<PhieuKham> GetAllPhieuKham()
        {
            return _pkRepo.GetAllPhieuKham().ToList();
        }

        public bool UpdatePhieuKham(PhieuKham pk)
        {
            return _pkRepo.UpdatePhieuKham(pk);
        }
    }
}
