using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IThongBaoSer
    {
        bool AddThongBao(ThongBao tb);
        bool UpdateThongBao(ThongBao tb);
        List<ThongBao> GetAllThongBao();
        ThongBao FindThongBao(Guid id);
    }
}
