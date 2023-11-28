using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    internal interface IAdminService
    {
        public List<Admin> GetAdmins();
        public bool Create(Admin adm);
        public bool Update(Admin adm);
        public Admin FindById(Guid id);
    }
}
