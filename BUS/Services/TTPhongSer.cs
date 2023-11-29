using A_DAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class TTPhongSer
    {
        TTPhongRepo _repo = new TTPhongRepo();
        public TTPhongSer()
        {
        }

        

        public List<TrangThaiPhong> GetTTPhong()
        {
            return _repo.GetTTPhong().ToList();
        }
        public bool AddTTPhong(TrangThaiPhong trangThaiPhong)
        {
            return _repo.AddTTPhong(trangThaiPhong);
        }
        public bool UpdateTTPhong(TrangThaiPhong trangThaiPhong)
        {
            return _repo.UpdateTTPhong(trangThaiPhong);
        }
    }
}
