using A_DAL.Repositories;
using DAL.DBContext;
using DAL.Enums;
using DAL.Models;
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


            var phong1 = new Phong();
            phong1.LoaiPhong = LoaiPhong.P405;

            var phong2 = new Phong();
            phong2.LoaiPhong = LoaiPhong.P603;

            var phong3 = new Phong();
            phong3.LoaiPhong = LoaiPhong.P113;

            var phong4 = new Phong();
            phong4.LoaiPhong = LoaiPhong.P406;

            db.Phongs.AddRange(new List<Phong>() { phong1, phong2, phong3, phong4 });
            db.SaveChanges();

            var ttPhongSer = new TTPhongRepo();


            foreach (var item in db.Phongs.ToList())
            {
                for (int i = 0; i < 7; i++)
                {
                    var ttPhong = new TrangThaiPhong();
                    ttPhong.Ngay = DateTime.Now.AddDays(i);
                    ttPhong.IdPhong = item.Id;
                    ttPhongSer.AddTTPhong(ttPhong);
                }
            }

            Console.WriteLine("Xong"); ;
            Console.ReadKey();
        }
    }
}
