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
        //private DBContext _context;
        //public CustomerRepo()
        //{
            
        //}
        public List<Customer> GetAll()
        {
            //return _context.Customer.GetAll();
            throw new NotImplementedException();

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
