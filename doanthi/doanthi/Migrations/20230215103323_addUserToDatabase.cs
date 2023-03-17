using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doanthi.Migrations
{
    public partial class addUserToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanphams",
                columns: table => new
                {
                    Sanpham_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.Sanpham_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phanquyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Hoadons",
                columns: table => new
                {
                    Hoadon_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaylapHD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    User_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadons", x => x.Hoadon_id);
                    table.ForeignKey(
                        name: "FK_Hoadons_Users_User_id1",
                        column: x => x.User_id1,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoadon_Tinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hoadon_id = table.Column<int>(type: "int", nullable: false),
                    Hoadon_id1 = table.Column<int>(type: "int", nullable: false),
                    Sanpham_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadon_Tinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoadon_Tinhs_Hoadons_Hoadon_id1",
                        column: x => x.Hoadon_id1,
                        principalTable: "Hoadons",
                        principalColumn: "Hoadon_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoadon_Tinhs_Sanphams_Sanpham_id",
                        column: x => x.Sanpham_id,
                        principalTable: "Sanphams",
                        principalColumn: "Sanpham_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_Tinhs_Hoadon_id1",
                table: "hoadon_Tinhs",
                column: "Hoadon_id1");

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_Tinhs_Sanpham_id",
                table: "hoadon_Tinhs",
                column: "Sanpham_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_User_id1",
                table: "Hoadons",
                column: "User_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoadon_Tinhs");

            migrationBuilder.DropTable(
                name: "Khachhangs");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
