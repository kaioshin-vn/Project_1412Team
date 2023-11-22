using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ILichKhamRepo
    {
        public List<LichKham> GetAll();
        public bool AddLichKham();
        public bool UpdateLichKham();
        public bool RemoveLichKham();
    }
}
