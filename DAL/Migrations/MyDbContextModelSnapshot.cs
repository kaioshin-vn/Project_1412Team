﻿// <auto-generated />
using System;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace A_DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passwprd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("DAL.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DichVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("DAL.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("HoaDonChiTiet");
                });

            modelBuilder.Entity("DAL.Models.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusClinicIndexDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusClinicIndexDate");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("DAL.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("BillsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MedicalBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BillsId");

                    b.HasIndex("MedicalBillId");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("DAL.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid?>("MedicaBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusdDoctorIndexDate")
                        .HasColumnType("int");

                    b.Property<bool>("visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MedicaBillId");

                    b.HasIndex("StatusdDoctorIndexDate");

                    b.ToTable("BacSi");
                });

            modelBuilder.Entity("DAL.Models.HealtRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HoSo");
                });

            modelBuilder.Entity("DAL.Models.MedicalBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HealtRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BillDetailId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("HealtRecordId");

                    b.HasIndex("RateId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PhieuKham");
                });

            modelBuilder.Entity("DAL.Models.Notice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("ThongBao");
                });

            modelBuilder.Entity("DAL.Models.Nurse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("StaffId");

                    b.ToTable("YTa");
                });

            modelBuilder.Entity("DAL.Models.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DanhGia");
                });

            modelBuilder.Entity("DAL.Models.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountShifts")
                        .HasColumnType("int");

                    b.Property<double>("Bonus")
                        .HasColumnType("float");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Luong");
                });

            modelBuilder.Entity("DAL.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descript")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DichVu");
                });

            modelBuilder.Entity("DAL.Models.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ShiftNumber")
                        .HasColumnType("int");

                    b.Property<int?>("StatusClinicIndexDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalBillId");

                    b.HasIndex("StatusClinicIndexDate");

                    b.ToTable("CaKham");
                });

            modelBuilder.Entity("DAL.Models.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Posittion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TimeKeepingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("TimeKeepingId");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("DAL.Models.Statiscal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SalaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("SalaryId");

                    b.ToTable("ThongKe");
                });

            modelBuilder.Entity("DAL.Models.StatusClinic", b =>
                {
                    b.Property<int>("IndexDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndexDate"));

                    b.Property<Guid>("IdClinic")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IndexDate");

                    b.ToTable("TrangThaiPhongKham");
                });

            modelBuilder.Entity("DAL.Models.StatusDoctor", b =>
                {
                    b.Property<int>("IndexDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndexDate"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IndexDate");

                    b.HasIndex("MedicalBillId");

                    b.HasIndex("ShiftId");

                    b.ToTable("TrangThaiBacSi");
                });

            modelBuilder.Entity("DAL.Models.TimeKeeping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdStaff")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ChamCong");
                });

            modelBuilder.Entity("DAL.Models.BillDetail", b =>
                {
                    b.HasOne("DAL.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId");

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("DAL.Models.Clinic", b =>
                {
                    b.HasOne("DAL.Models.StatusClinic", "StatusClinic")
                        .WithMany("Clinics")
                        .HasForeignKey("StatusClinicIndexDate");

                    b.Navigation("StatusClinic");
                });

            modelBuilder.Entity("DAL.Models.Customer", b =>
                {
                    b.HasOne("DAL.Models.Bill", "Bills")
                        .WithMany("Customers")
                        .HasForeignKey("BillsId");

                    b.HasOne("DAL.Models.MedicalBill", "MedicalBill")
                        .WithMany("Customers")
                        .HasForeignKey("MedicalBillId");

                    b.Navigation("Bills");

                    b.Navigation("MedicalBill");
                });

            modelBuilder.Entity("DAL.Models.Doctor", b =>
                {
                    b.HasOne("DAL.Models.MedicalBill", "MedicaBill")
                        .WithMany("Doctors")
                        .HasForeignKey("MedicaBillId");

                    b.HasOne("DAL.Models.StatusDoctor", "StatusdDoctor")
                        .WithMany("Doctors")
                        .HasForeignKey("StatusdDoctorIndexDate");

                    b.Navigation("MedicaBill");

                    b.Navigation("StatusdDoctor");
                });

            modelBuilder.Entity("DAL.Models.MedicalBill", b =>
                {
                    b.HasOne("DAL.Models.BillDetail", "BillDetail")
                        .WithMany("MedicalBills")
                        .HasForeignKey("BillDetailId");

                    b.HasOne("DAL.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("DAL.Models.HealtRecord", "HealtRecord")
                        .WithMany("MedicalBills")
                        .HasForeignKey("HealtRecordId");

                    b.HasOne("DAL.Models.Rate", "Rate")
                        .WithMany("MedicalBills")
                        .HasForeignKey("RateId");

                    b.HasOne("DAL.Models.Service", "Service")
                        .WithMany("MedicalBills")
                        .HasForeignKey("ServiceId");

                    b.Navigation("BillDetail");

                    b.Navigation("Clinic");

                    b.Navigation("HealtRecord");

                    b.Navigation("Rate");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DAL.Models.Notice", b =>
                {
                    b.HasOne("DAL.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("DAL.Models.Nurse", b =>
                {
                    b.HasOne("DAL.Models.Bill", "Bill")
                        .WithMany("Nurses")
                        .HasForeignKey("BillId");

                    b.HasOne("DAL.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("DAL.Models.Salary", b =>
                {
                    b.HasOne("DAL.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("DAL.Models.Shift", b =>
                {
                    b.HasOne("DAL.Models.MedicalBill", "MedicalBill")
                        .WithMany("Shifts")
                        .HasForeignKey("MedicalBillId");

                    b.HasOne("DAL.Models.StatusClinic", "StatusClinic")
                        .WithMany("Shifts")
                        .HasForeignKey("StatusClinicIndexDate");

                    b.Navigation("MedicalBill");

                    b.Navigation("StatusClinic");
                });

            modelBuilder.Entity("DAL.Models.Staff", b =>
                {
                    b.HasOne("DAL.Models.Admin", "Admin")
                        .WithMany("Staff")
                        .HasForeignKey("AdminId");

                    b.HasOne("DAL.Models.Doctor", "Doctor")
                        .WithMany("Staff")
                        .HasForeignKey("DoctorId");

                    b.HasOne("DAL.Models.TimeKeeping", "TimeKeeping")
                        .WithMany("Staff")
                        .HasForeignKey("TimeKeepingId");

                    b.Navigation("Admin");

                    b.Navigation("Doctor");

                    b.Navigation("TimeKeeping");
                });

            modelBuilder.Entity("DAL.Models.Statiscal", b =>
                {
                    b.HasOne("DAL.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Salary", "Salary")
                        .WithMany("Statiscals")
                        .HasForeignKey("SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("DAL.Models.StatusDoctor", b =>
                {
                    b.HasOne("DAL.Models.MedicalBill", "MedicalBill")
                        .WithMany("StatusDoctors")
                        .HasForeignKey("MedicalBillId");

                    b.HasOne("DAL.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId");

                    b.Navigation("MedicalBill");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("DAL.Models.Admin", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("DAL.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("Customers");

                    b.Navigation("Nurses");
                });

            modelBuilder.Entity("DAL.Models.BillDetail", b =>
                {
                    b.Navigation("MedicalBills");
                });

            modelBuilder.Entity("DAL.Models.Doctor", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("DAL.Models.HealtRecord", b =>
                {
                    b.Navigation("MedicalBills");
                });

            modelBuilder.Entity("DAL.Models.MedicalBill", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Doctors");

                    b.Navigation("Shifts");

                    b.Navigation("StatusDoctors");
                });

            modelBuilder.Entity("DAL.Models.Rate", b =>
                {
                    b.Navigation("MedicalBills");
                });

            modelBuilder.Entity("DAL.Models.Salary", b =>
                {
                    b.Navigation("Statiscals");
                });

            modelBuilder.Entity("DAL.Models.Service", b =>
                {
                    b.Navigation("MedicalBills");
                });

            modelBuilder.Entity("DAL.Models.StatusClinic", b =>
                {
                    b.Navigation("Clinics");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("DAL.Models.StatusDoctor", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("DAL.Models.TimeKeeping", b =>
                {
                    b.Navigation("Staff");
                });
#pragma warning restore 612, 618
        }
    }
}