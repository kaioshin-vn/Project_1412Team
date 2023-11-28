using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IPhongRepo
    {
        bool AddPhong(Phong p);
        bool UpdatePhong(Phong p);
        List<Phong> GetAllPhong();
        Phong FindPhongId(Guid id);

    }
}
