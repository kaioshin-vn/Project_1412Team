using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface ILuongSer
    {
        bool AddLuong(Luong l);
        bool UpdateLuong(Luong l);
        List<Luong> GetAllLuong();
        Luong FindLuong(Guid id);
    }
}
