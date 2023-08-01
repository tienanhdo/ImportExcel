using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportExcel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcelDataModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STK_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STK_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ma_NH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten_NH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU_CODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BARCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ĐVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ma_Thue_Suat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ton_Kho = table.Column<int>(type: "int", nullable: false),
                    Gia_Tri_Ton = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelDataModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelDataModels");
        }
    }
}
