using A_DAL.IRepositories;
using A_DAL.Migrations;
using DAL.DBContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        MyDbContext dbcontext = new MyDbContext();
        public AdminRepository()
        {
            GetAdmins();
        }
        public bool Create(Admin adm)
        {
            dbcontext.Admins.Add(adm);
            return dbcontext.SaveChanges() > 0;
        }

        public Admin FindById(Guid id)
        {
            return dbcontext.Admins.Find(id);

        }

        public List<Admin> GetAdmins()
        {
            return dbcontext.Admins.ToList();
        }

        public bool Update(Admin adm)
        {
            dbcontext.Admins.Update(adm);
            return dbcontext.SaveChanges() > 0;
        }
    }
}
