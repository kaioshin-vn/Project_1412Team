using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface ILuongRepo
    {
        bool AddLuong(Luong l);
        bool UpdateLuong(Luong l);
        List<Luong> GetAllLuong();
        Luong FindLuongId(Guid id);
    }
}
