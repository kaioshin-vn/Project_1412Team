using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DAL
{
    class Program
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
            public ICollection<ProductDetails> Orders { get; set; }
        }

        public class Order
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public virtual Customer Customer { get; set; }
            public ICollection<ProductDetails> Products { get; set; }
        }

        [PrimaryKey("IdOder" , new string[] {"IdProduct"}) ]
        public class ProductDetails
        {

            //string[] strings = new string[2] { "IdOder", "IdProduct" };

            public int IdOder { get; set; }
         //   [Key]            
            public int IdProduct { get; set; }
          //  [Key]

            public int Quantity { get; set; }
            public float Price { get; set; }
            [ForeignKey("IdProduct")]
            public virtual Product Product { get; set; }
            [ForeignKey("IdOder")]
            public virtual Order Order { get; set; }
        }

        public class ProductsContext : DbContext
        {
            // Thuộc tính products kiểu DbSet<Product> cho biết CSDL có bảng mà
            // thông tin về bảng dữ liệu biểu diễn bởi model Product
            public DbSet<Product> products { set; get; }



            // Chuỗi kết nối tới CSDL (MS SQL Server)
            private const string connectionString = @"Data Source=.;Initial Catalog=test_nn;Integrated Security=True ; TrustServerCertificate=true";

            // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
            // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(connectionString);
            }
            
        }

        static void Main()
        {
            var db = new ProductsContext();
            db.Database.EnsureCreated();
            Console.WriteLine("Tc");
            Console.ReadKey(); 
        }
    }
}
