using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IPhongSer
    {
        bool AddPhong(Phong p);
        bool UpdatePhong(Phong p);
        List<Phong> GetAllPhong();
        Phong FindPhong(Guid id);
    }
}
