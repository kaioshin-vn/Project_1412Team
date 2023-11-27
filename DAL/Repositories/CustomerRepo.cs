using DAL.DBContext;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private MyDbContext _context;
        //public CustomerRepo()
        //{
            
        //}
        public List<KhachHang> GetAll()
        {
            return _context.Customers.ToList();
        }
        public bool AddLichKham()
        {
            throw new NotImplementedException();
        }
        public bool UpdateLichKham()
        {
            throw new NotImplementedException();
        }
        public bool RemoveLichKham()
        {
            throw new NotImplementedException();
        }

       
    }
}
