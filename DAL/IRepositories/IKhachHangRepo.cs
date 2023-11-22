using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IKhachHangRepo
    {
        public List<KhachHang> GetAll();
        public bool Add();
        public bool Update();
        public bool Delete();
    }
}
