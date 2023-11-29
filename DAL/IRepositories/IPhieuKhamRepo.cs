using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    public interface IPhieuKhamRepo
    {
        bool AddPhieuKham(PhieuKham pk);
        bool UpdatePhieuKham(PhieuKham pk);
        List<PhieuKham> GetAllPhieuKham();
        PhieuKham FindPhieuKhamId(Guid id);
    }
}
