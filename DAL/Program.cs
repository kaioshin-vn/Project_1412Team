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
                for (int i = 0; i < 8; i++)
                {
                    var ttPhong = new TrangThaiPhong();
                    ttPhong.Ngay = DateTime.Now.AddDays(i);
                    ttPhong.IdPhong = item.Id;
                    ttPhongSer.AddTTPhong(ttPhong);
                }
            }

            var nv = new NhanVien();
            nv.ChucVu = LoaiNhanVien.Admin;
            nv.SoDienThoai = "0978040960";
            nv.DiaChi = "làng Ngọc Nhuế , xã Tân Phúc , huyện Ân Thi , tỉnh Hưng Yên";
            nv.GioiTinh = true;
            nv.Mota = "Là người thân thiện,dễ gần,hài hước";
            nv.MatKhau = "1234";
            nv.NgaySinh = DateTime.Parse("04/06/2004");
            nv.Ten = "Đặng Đình Giáp";
            db.NhanViens.Add(nv);
            db.SaveChanges();

            Console.WriteLine("Xong"); ;
            Console.ReadKey();
        }
    }
}
