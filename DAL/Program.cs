using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void WriteToScreen()
        { 
            //check conflict github side
            //check Phong 
            //giap
            //giapdd
            //tant5tuu
            //fvfv
            //quan dfef

        }

        static void Main()
        {
            var db = new MyDbContext();
            db.Database.EnsureCreated();
            Console.WriteLine("Tc");
            Console.ReadKey(); 
        }
    }
}
