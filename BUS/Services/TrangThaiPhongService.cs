using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class TrangThaiPhongSerVice
    {
        MyDbContext myDbContext = new MyDbContext();

        public bool UpdateTrangThaiPhong(TrangThaiPhong TrangThaiPhong)
        {
            myDbContext.TrangThaiPhongs.Update(TrangThaiPhong);
            return true;
        }
        public List<TrangThaiPhong> GetAllTrangThaiPhong()
        {
            return myDbContext.TrangThaiPhongs.ToList();
        }
    }
}
