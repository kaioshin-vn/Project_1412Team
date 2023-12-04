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
    public class ThongBaoSer : IThongBaoSer
    {
        private readonly IThongBaoRepo _tbRepo;
        public ThongBaoSer()
        {
            _tbRepo = new ThongBaoRepo();
        }
        public bool AddThongBao(ThongBao tb)
        {
            return _tbRepo.AddThongBao(tb);
        }


        public List<ThongBao> GetListThongBaoChuaTH()
        {
            return _tbRepo.GetAllThongBao().Where(a => a.TrangThai == false).ToList();
        }
        public List<ThongBao> GetAllThongBao()
        {
            return _tbRepo.GetAllThongBao().ToList();
        }

        public bool UpdateThongBao(ThongBao tb)
        {
            return _tbRepo.UpdateThongBao(tb);
        }

        public ThongBao FindThongBao(Guid id)
        {
            return _tbRepo.FindThongBaoId(id);
        }
    }
}
