using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FE
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(){}
        public MyDbContext(DbContextOptions options) : base(options){}

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Rate> Rates { get; set; } 
        public DbSet<HealtRecord> HealtRecords { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O08I15N\\SQLEXPRESS01;Initial Catalog=Duan1;Integrated Security=True");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
    }
}
