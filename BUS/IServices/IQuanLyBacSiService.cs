using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface IQuanLyBacSiService
    {
        public List<BacSi> GetBacSis();
        public bool Create(BacSi bs);
        public bool Update(BacSi bs);
        public BacSi FindById(Guid id);
    }
}
