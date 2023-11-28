using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface ITTPhongRepo
    {
        List<TrangThaiPhong> GetTTPhong();
        TrangThaiPhong FindTTPhong(int id);
        bool AddTTPhong(TrangThaiPhong trangThaiPhong);
        bool UpdateTTPhong(TrangThaiPhong trangThaiPhong);
    }
}
