using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_DAL.Migrations
{
    /// <inheritdoc />
    public partial class dbbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwprd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiPhongKham",
                columns: table => new
                {
                    IndexDate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdShift = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClinic = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiPhongKham", x => x.IndexDate);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_BillId",
                        column: x => x.BillId,
                        principalTable: "HoaDon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusClinicIndexDate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phong_TrangThaiPhongKham_StatusClinicIndexDate",
                        column: x => x.StatusClinicIndexDate,
                        principalTable: "TrangThaiPhongKham",
                        principalColumn: "IndexDate");
                });

            migrationBuilder.CreateTable(
                name: "PhieuKham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    BillDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HealtRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuKham_DanhGia_RateId",
                        column: x => x.RateId,
                        principalTable: "DanhGia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuKham_DichVu_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "DichVu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuKham_HoSo_HealtRecordId",
                        column: x => x.HealtRecordId,
                        principalTable: "HoSo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuKham_HoaDonChiTiet_BillDetailId",
                        column: x => x.BillDetailId,
                        principalTable: "HoaDonChiTiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhieuKham_Phong_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaKham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftNumber = table.Column<int>(type: "int", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusClinicIndexDate = table.Column<int>(type: "int", nullable: true),
                    MedicalBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaKham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaKham_PhieuKham_MedicalBillId",
                        column: x => x.MedicalBillId,
                        principalTable: "PhieuKham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaKham_TrangThaiPhongKham_StatusClinicIndexDate",
                        column: x => x.StatusClinicIndexDate,
                        principalTable: "TrangThaiPhongKham",
                        principalColumn: "IndexDate");
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    BillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHang_HoaDon_BillsId",
                        column: x => x.BillsId,
                        principalTable: "HoaDon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHang_PhieuKham_MedicalBillId",
                        column: x => x.MedicalBillId,
                        principalTable: "PhieuKham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiBacSi",
                columns: table => new
                {
                    IndexDate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdShift = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiBacSi", x => x.IndexDate);
                    table.ForeignKey(
                        name: "FK_TrangThaiBacSi_CaKham_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "CaKham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrangThaiBacSi_PhieuKham_MedicalBillId",
                        column: x => x.MedicalBillId,
                        principalTable: "PhieuKham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BacSi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false),
                    StatusdDoctorIndexDate = table.Column<int>(type: "int", nullable: true),
                    MedicaBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacSi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacSi_PhieuKham_MedicaBillId",
                        column: x => x.MedicaBillId,
                        principalTable: "PhieuKham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BacSi_TrangThaiBacSi_StatusdDoctorIndexDate",
                        column: x => x.StatusdDoctorIndexDate,
                        principalTable: "TrangThaiBacSi",
                        principalColumn: "IndexDate");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posittion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeKeepingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanVien_BacSi_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "BacSi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanVien_ChamCong_TimeKeepingId",
                        column: x => x.TimeKeepingId,
                        principalTable: "ChamCong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountShifts = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_StaffId",
                        column: x => x.StaffId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongBao_NhanVien_StaffId",
                        column: x => x.StaffId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YTa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YTa_HoaDon_BillId",
                        column: x => x.BillId,
                        principalTable: "HoaDon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YTa_NhanVien_StaffId",
                        column: x => x.StaffId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongKe_HoaDon_BillId",
                        column: x => x.BillId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongKe_Luong_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Luong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacSi_MedicaBillId",
                table: "BacSi",
                column: "MedicaBillId");

            migrationBuilder.CreateIndex(
                name: "IX_BacSi_StatusdDoctorIndexDate",
                table: "BacSi",
                column: "StatusdDoctorIndexDate");

            migrationBuilder.CreateIndex(
                name: "IX_CaKham_MedicalBillId",
                table: "CaKham",
                column: "MedicalBillId");

            migrationBuilder.CreateIndex(
                name: "IX_CaKham_StatusClinicIndexDate",
                table: "CaKham",
                column: "StatusClinicIndexDate");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_BillId",
                table: "HoaDonChiTiet",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_BillsId",
                table: "KhachHang",
                column: "BillsId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MedicalBillId",
                table: "KhachHang",
                column: "MedicalBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_StaffId",
                table: "Luong",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_AdminId",
                table: "NhanVien",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_DoctorId",
                table: "NhanVien",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TimeKeepingId",
                table: "NhanVien",
                column: "TimeKeepingId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_BillDetailId",
                table: "PhieuKham",
                column: "BillDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_ClinicId",
                table: "PhieuKham",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_HealtRecordId",
                table: "PhieuKham",
                column: "HealtRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_RateId",
                table: "PhieuKham",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_ServiceId",
                table: "PhieuKham",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_StatusClinicIndexDate",
                table: "Phong",
                column: "StatusClinicIndexDate");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_StaffId",
                table: "ThongBao",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKe_BillId",
                table: "ThongKe",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKe_SalaryId",
                table: "ThongKe",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiBacSi_MedicalBillId",
                table: "TrangThaiBacSi",
                column: "MedicalBillId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiBacSi_ShiftId",
                table: "TrangThaiBacSi",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_YTa_BillId",
                table: "YTa",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_YTa_StaffId",
                table: "YTa",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThongKe");

            migrationBuilder.DropTable(
                name: "YTa");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "BacSi");

            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "TrangThaiBacSi");

            migrationBuilder.DropTable(
                name: "CaKham");

            migrationBuilder.DropTable(
                name: "PhieuKham");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "HoSo");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "TrangThaiPhongKham");
        }
    }
}
