using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class QuanLyBacSiService : IQuanLyBacSiService
    {
        BacSiRepository _BacSiRepository = new BacSiRepository();

        public bool Create(BacSi bs)
        {
            _BacSiRepository.Create(bs);
            return true;
        }

        public BacSi FindById(Guid id)
        {
            return _BacSiRepository.FindById(id);
        }

        public List<BacSi> GetBacSis()
        {
            return _BacSiRepository.GetBacSis().ToList();
        }

        public bool Update(BacSi bs)
        {
            _BacSiRepository.Update(bs);
            return true;
        }
    }
}
