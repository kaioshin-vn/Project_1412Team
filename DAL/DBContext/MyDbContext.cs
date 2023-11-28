using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<HoaDon> Bills { get; set; }
        public DbSet<HoaDonChiTiet> BillDetails { get; set; }
        public DbSet<DanhGia> Rates { get; set; }
        public DbSet<LichSuKham> HealtRecords { get; set; }
        public DbSet<DichVu> Services { get; set; }
        public DbSet<Phong> Clinics { get; set; }
        public DbSet<KhachHang> Customers { get; set; }
        public DbSet<BacSi> Doctors { get; set; }
        public DbSet<PhieuKham> MedicalBills { get; set; }
        public DbSet<ThongBao> Notices { get; set; }
        public DbSet<YTa> Nurses { get; set; }
        public DbSet<Luong> Salaries { get; set; }
        public DbSet<CaKham> Shifts { get; set; }
        public DbSet<NhanVien> Staffs { get; set; }
        public DbSet<ThongKe> Statiscals { get; set; }
        public DbSet<TrangThaiPhong> StatusClinics { get; set; }
        public DbSet<TrangThaiNhanVien> StatusDoctors { get; set; }
        public DbSet<ChamCong> TimeKeepings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DuAn1;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Duan1;Integrated Security=True ; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrangThaiNhanVien>()
           .Property(p => p.IdNgay)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn();

            modelBuilder.Entity<TrangThaiPhong>()
           .Property(p => p.IdNgay)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn();

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasIndex(e => e.SoDienThoai).IsUnique();
            });

        }
    }
}
