using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<HealtRecord> HealtRecords { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalBill> MedicalBills { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Statiscal> Statiscals { get; set; }
        public DbSet<StatusClinic> StatusClinics { get; set; }
        public DbSet<StatusDoctor> StatusDoctors { get; set; }
        public DbSet<TimeKeeping> TimeKeepings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DuAn1;Integrated Security=True;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O08I15N\SQLEXPRESS01;Initial Catalog=Duan1;Integrated Security=True");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}S
    }
}
