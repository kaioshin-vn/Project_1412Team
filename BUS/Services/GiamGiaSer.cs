using A_DAL.Models;
using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.Services
{
    public class GiamGiaSer
    {
        MyDbContext dbContext;

        public void AddGiamGia (GiamGia giamGia )
        {
            dbContext = new MyDbContext ();
            dbContext.GiamGias.Add ( giamGia );
        }

        public void UpdateGiamGia(GiamGia giamGia)
        {
            dbContext = new MyDbContext();
            dbContext.GiamGias.Update(giamGia);
        }

        public GiamGia GetGiamGiaGanNhat()
        {
            dbContext= new MyDbContext ();
            var giamGiaGanNhat = dbContext.GiamGias.OrderByDescending(a => a.id).FirstOrDefault();
            return giamGiaGanNhat;
 
        }

        public GiamGia FindGiamGia (int id)
        {
            dbContext= new MyDbContext ();
            return dbContext.GiamGias.FirstOrDefault(a => a.id == id);
        }


    }
}
