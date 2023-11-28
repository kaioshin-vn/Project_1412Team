using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IBacSiRepository
    {
        public List<BacSi> GetBacSis();
        public bool Create(BacSi bs);
        public bool Update(BacSi bs);
        public BacSi FindById(Guid id);
    }
}
