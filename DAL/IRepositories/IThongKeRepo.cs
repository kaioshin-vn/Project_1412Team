using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IThongKeRepo
    {
        List<ThongKe> GetThongKe();
        ThongKe FindThongKe(Guid id);
        bool AddThongKe(ThongKe thongKe);
        bool UpdateThongKe(ThongKe thongKe);
    }
}
