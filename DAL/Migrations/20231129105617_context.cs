using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_DAL.Migrations
{
    /// <inheritdoc />
    public partial class context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaKham",
                columns: table => new
                {
                    IdCaKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STTCaKham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaKham", x => x.IdCaKham);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    IdDichVu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<int>(type: "int", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.IdDichVu);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhanTramGiamGia = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IdKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: true),
                    ChucVu = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaKhamIdCaKham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IdNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_CaKham_CaKhamIdCaKham",
                        column: x => x.CaKhamIdCaKham,
                        principalTable: "CaKham",
                        principalColumn: "IdCaKham");
                    table.ForeignKey(
                        name: "FK_NhanVien_Phong_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiPhong",
                columns: table => new
                {
                    IdNgay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPhong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCaKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiPhong", x => x.IdNgay);
                    table.ForeignKey(
                        name: "FK_TrangThaiPhong_CaKham_IdCaKham",
                        column: x => x.IdCaKham,
                        principalTable: "CaKham",
                        principalColumn: "IdCaKham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrangThaiPhong_Phong_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_NhanVien_IdAdmin",
                        column: x => x.IdAdmin,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThaiCham = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.IdNhanVien);
                    table.ForeignKey(
                        name: "FK_ChamCong_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.IdHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    IdLuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    Thuong = table.Column<int>(type: "int", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    SoCong = table.Column<int>(type: "int", nullable: true),
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.IdLuong);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    IdThongBao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    ChapNhan = table.Column<bool>(type: "bit", nullable: true),
                    IdNguoiGui = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.IdThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBao_NhanVien_IdNguoiGui",
                        column: x => x.IdNguoiGui,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiNhanVien",
                columns: table => new
                {
                    IdNgay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    IdCaKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiNhanVien", x => x.IdNgay);
                    table.ForeignKey(
                        name: "FK_TrangThaiNhanVien_CaKham_IdCaKham",
                        column: x => x.IdCaKham,
                        principalTable: "CaKham",
                        principalColumn: "IdCaKham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrangThaiNhanVien_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongKe",
                columns: table => new
                {
                    IdThongKe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThongKe = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdLuong = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKe", x => x.IdThongKe);
                    table.ForeignKey(
                        name: "FK_ThongKe_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "IdHoaDon");
                    table.ForeignKey(
                        name: "FK_ThongKe_Luong_IdLuong",
                        column: x => x.IdLuong,
                        principalTable: "Luong",
                        principalColumn: "IdLuong");
                });

            migrationBuilder.CreateTable(
                name: "PhieuKham",
                columns: table => new
                {
                    IdPhieuKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBacSi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDichVu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCaKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPhong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdYTa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNgay = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKham", x => x.IdPhieuKham);
                    table.ForeignKey(
                        name: "FK_PhieuKham_CaKham_IdCaKham",
                        column: x => x.IdCaKham,
                        principalTable: "CaKham",
                        principalColumn: "IdCaKham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuKham_DichVu_IdDichVu",
                        column: x => x.IdDichVu,
                        principalTable: "DichVu",
                        principalColumn: "IdDichVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuKham_KhachHang_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuKham_Phong_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuKham_TrangThaiNhanVien_IdNgay",
                        column: x => x.IdNgay,
                        principalTable: "TrangThaiNhanVien",
                        principalColumn: "IdNgay");
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    IdDanhGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPhieuKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.IdDanhGia);
                    table.ForeignKey(
                        name: "FK_DanhGia_PhieuKham_IdPhieuKham",
                        column: x => x.IdPhieuKham,
                        principalTable: "PhieuKham",
                        principalColumn: "IdPhieuKham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPhieuKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => new { x.IdHoaDon, x.IdPhieuKham });
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "IdHoaDon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_PhieuKham_IdPhieuKham",
                        column: x => x.IdPhieuKham,
                        principalTable: "PhieuKham",
                        principalColumn: "IdPhieuKham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuKham",
                columns: table => new
                {
                    IdPhieuKham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KetQua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuKham", x => x.IdPhieuKham);
                    table.ForeignKey(
                        name: "FK_LichSuKham_PhieuKham_IdPhieuKham",
                        column: x => x.IdPhieuKham,
                        principalTable: "PhieuKham",
                        principalColumn: "IdPhieuKham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_IdPhieuKham",
                table: "DanhGia",
                column: "IdPhieuKham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdNhanVien",
                table: "HoaDon",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdPhieuKham",
                table: "HoaDonChiTiet",
                column: "IdPhieuKham");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_IdNhanVien",
                table: "Luong",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_CaKhamIdCaKham",
                table: "NhanVien",
                column: "CaKhamIdCaKham");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhongId",
                table: "NhanVien",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_SoDienThoai",
                table: "NhanVien",
                column: "SoDienThoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_IdCaKham",
                table: "PhieuKham",
                column: "IdCaKham");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_IdDichVu",
                table: "PhieuKham",
                column: "IdDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_IdKhachHang",
                table: "PhieuKham",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_IdNgay",
                table: "PhieuKham",
                column: "IdNgay");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_IdPhong",
                table: "PhieuKham",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_IdNguoiGui",
                table: "ThongBao",
                column: "IdNguoiGui");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKe_IdHoaDon",
                table: "ThongKe",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKe_IdLuong",
                table: "ThongKe",
                column: "IdLuong");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiNhanVien_IdCaKham",
                table: "TrangThaiNhanVien",
                column: "IdCaKham");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiNhanVien_IdNhanVien",
                table: "TrangThaiNhanVien",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiPhong_IdCaKham",
                table: "TrangThaiPhong",
                column: "IdCaKham");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiPhong_IdPhong",
                table: "TrangThaiPhong",
                column: "IdPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "LichSuKham");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThongKe");

            migrationBuilder.DropTable(
                name: "TrangThaiPhong");

            migrationBuilder.DropTable(
                name: "PhieuKham");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "TrangThaiNhanVien");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "CaKham");

            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}
