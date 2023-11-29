using A_DAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class YTaSer
    {
        YTaRepo _repo = new YTaRepo();

        public YTaSer()
        {
        }
        public List<YTa> GetYTa()
        {
            return _repo.GetYTa().ToList();
        }
        public bool AddYTa(YTa yTa)
        {
            return _repo.AddYTa(yTa);
        }
        public bool UpdateYTa(YTa yTa)
        {
            return _repo.UpdateYTa(yTa);
        }
    }
}
