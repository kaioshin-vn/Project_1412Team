using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IYTaRepo
    {
        List<YTa> GetYTa();
        YTa FindYTa(Guid id);
        bool AddYTa(YTa yTa);
        bool UpdateYTa(YTa yTa);
    }
}
