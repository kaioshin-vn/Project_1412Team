using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.IRepositories
{
    internal interface IAdminRepository
    {
        public List<Admin> GetAdmins();
        public bool Create(Admin adm);
        public bool Update(Admin adm);
        public Admin FindById(Guid id);
    }
}
