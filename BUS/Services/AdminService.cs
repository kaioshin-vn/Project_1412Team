using A_DAL.Repositories;
using B_BUS.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class AdminService : IAdminService
    {
        AdminRepository _adminRepository = new AdminRepository();

        public bool Create(Admin adm)
        {
            _adminRepository .Create(adm);
            return true;
        }

        public Admin FindById(Guid id)
        {
            return _adminRepository.FindById(id);
        }

        public List<Admin> GetAdmins()
        {
            return _adminRepository.GetAdmins().ToList();
        }

        public bool Update(Admin adm)
        {
            _adminRepository.Update(adm);
            return true;
        }
    }
}
