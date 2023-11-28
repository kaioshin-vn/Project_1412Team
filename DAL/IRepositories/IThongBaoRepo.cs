using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IThongBaoRepo
    {
        bool AddThongBao(ThongBao tb);
        bool UpdateThongBao(ThongBao tb);
        List<ThongBao> GetAllThongBao();
        ThongBao FindThongBaoId(Guid id);
    }
}
