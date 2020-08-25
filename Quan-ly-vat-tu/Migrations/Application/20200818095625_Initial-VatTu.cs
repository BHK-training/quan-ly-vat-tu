using Microsoft.EntityFrameworkCore.Migrations;

namespace Quan_ly_vat_tu.Migrations.Application
{
    public partial class InitialVatTu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    maKho = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKho = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kho", x => x.maKho);
                });

            migrationBuilder.CreateTable(
                name: "VatTu",
                columns: table => new
                {
                    maVatTu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenVatTu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    gia = table.Column<double>(type: "float", nullable: false),
                    maKho = table.Column<int>(nullable: false),
                    khomaKho = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTu", x => x.maVatTu);
                    table.ForeignKey(
                        name: "FK_VatTu_Kho_khomaKho",
                        column: x => x.khomaKho,
                        principalTable: "Kho",
                        principalColumn: "maKho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VatTu_khomaKho",
                table: "VatTu",
                column: "khomaKho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VatTu");

            migrationBuilder.DropTable(
                name: "Kho");
        }
    }
}
