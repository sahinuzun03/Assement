using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportRequest.Api.Migrations
{
    public partial class Firstinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportStatus = table.Column<int>(type: "int", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReportResult = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetails");
        }
    }
}
