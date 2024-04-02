﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental1.Migrations
{
    /// <inheritdoc />
    public partial class password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GPLX = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImgGplx = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "date", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhNangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhNangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XeTinhNangViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHang = table.Column<int>(type: "int", nullable: false),
                    IdLoaiXe = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Bienso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soghe = table.Column<int>(type: "int", nullable: false),
                    Truyendong = table.Column<int>(type: "int", nullable: false),
                    LoaiNl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeTinhNangViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loaixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HangId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loaixes_Hangs_HangId",
                        column: x => x.HangId,
                        principalTable: "Hangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCus = table.Column<int>(type: "int", nullable: false),
                    IdCarOwner = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Noidung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Danhgia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_InfoUsers_IdCarOwner",
                        column: x => x.IdCarOwner,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_InfoUsers_IdCus",
                        column: x => x.IdCus,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCus = table.Column<int>(type: "int", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    Paymentdate = table.Column<DateTime>(type: "date", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDons_InfoUsers_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckBoxItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    XeTinhNangViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBoxItem_XeTinhNangViewModel_XeTinhNangViewModelId",
                        column: x => x.XeTinhNangViewModelId,
                        principalTable: "XeTinhNangViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InfoXes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHang = table.Column<int>(type: "int", nullable: false),
                    IdLoaiXe = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Bienso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Soghe = table.Column<int>(type: "int", nullable: false),
                    Truyendong = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    LoaiNl = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoXes_Hangs_IdHang",
                        column: x => x.IdHang,
                        principalTable: "Hangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InfoXes_Loaixes_IdLoaiXe",
                        column: x => x.IdLoaiXe,
                        principalTable: "Loaixes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InfoXes_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInfo = table.Column<int>(type: "int", nullable: false),
                    IdChuXe = table.Column<int>(type: "int", nullable: false),
                    Loinhan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Diachixe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LimitXechay = table.Column<int>(type: "int", nullable: false),
                    GiaVuot = table.Column<double>(type: "float", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GioiHankmgiaoxe = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_InfoUsers_IdChuXe",
                        column: x => x.IdChuXe,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhams_InfoXes_IdInfo",
                        column: x => x.IdInfo,
                        principalTable: "InfoXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XeTinhNangs",
                columns: table => new
                {
                    Idxe = table.Column<int>(type: "int", nullable: false),
                    Idtinhnang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeTinhNangs", x => new { x.Idtinhnang, x.Idxe });
                    table.ForeignKey(
                        name: "FK_XeTinhNangs_InfoXes_Idxe",
                        column: x => x.Idxe,
                        principalTable: "InfoXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XeTinhNangs_TinhNangs_Idtinhnang",
                        column: x => x.Idtinhnang,
                        principalTable: "TinhNangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTHDs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDHD = table.Column<int>(type: "int", nullable: false),
                    IdSp = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    Checkin = table.Column<DateTime>(type: "date", nullable: false),
                    Checkout = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHDs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CTHDs_HoaDons_IDHD",
                        column: x => x.IDHD,
                        principalTable: "HoaDons",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CTHDs_SanPhams_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonDatXes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSp = table.Column<int>(type: "int", nullable: false),
                    IdCus = table.Column<int>(type: "int", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkin = table.Column<DateTime>(type: "date", nullable: false),
                    checkout = table.Column<DateTime>(type: "date", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatXes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonDatXes_InfoUsers_IdCus",
                        column: x => x.IdCus,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonDatXes_InfoUsers_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "InfoUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonDatXes_SanPhams_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxItem_XeTinhNangViewModelId",
                table: "CheckBoxItem",
                column: "XeTinhNangViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CTHDs_IDHD",
                table: "CTHDs",
                column: "IDHD");

            migrationBuilder.CreateIndex(
                name: "IX_CTHDs_IdSp",
                table: "CTHDs",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatXes_IdCus",
                table: "DonDatXes",
                column: "IdCus");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatXes_IdOwner",
                table: "DonDatXes",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatXes_IdSp",
                table: "DonDatXes",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_IdCarOwner",
                table: "Feedbacks",
                column: "IdCarOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_IdCus",
                table: "Feedbacks",
                column: "IdCus");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdOwner",
                table: "HoaDons",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_InfoXes_IdHang",
                table: "InfoXes",
                column: "IdHang");

            migrationBuilder.CreateIndex(
                name: "IX_InfoXes_IdLoaiXe",
                table: "InfoXes",
                column: "IdLoaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_InfoXes_IdUser",
                table: "InfoXes",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Loaixes_HangId",
                table: "Loaixes",
                column: "HangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdChuXe",
                table: "SanPhams",
                column: "IdChuXe");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdInfo",
                table: "SanPhams",
                column: "IdInfo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_XeTinhNangs_Idxe",
                table: "XeTinhNangs",
                column: "Idxe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckBoxItem");

            migrationBuilder.DropTable(
                name: "CTHDs");

            migrationBuilder.DropTable(
                name: "DonDatXes");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "XeTinhNangs");

            migrationBuilder.DropTable(
                name: "XeTinhNangViewModel");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TinhNangs");

            migrationBuilder.DropTable(
                name: "InfoUsers");

            migrationBuilder.DropTable(
                name: "InfoXes");

            migrationBuilder.DropTable(
                name: "Loaixes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hangs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
