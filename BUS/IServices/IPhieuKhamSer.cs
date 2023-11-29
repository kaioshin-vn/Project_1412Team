using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IPhieuKhamSer
    {
        bool AddPhieuKham(PhieuKham pk);
        bool UpdatePhieuKham(PhieuKham pk);
        List<PhieuKham> GetAllPhieuKham();
        PhieuKham FindPhieuKham(Guid id);
    }
}
