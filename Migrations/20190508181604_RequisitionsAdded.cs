using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRV7.Migrations
{
    public partial class RequisitionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllRequisitions",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeFK = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    TimeOffType = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    TotalDays = table.Column<int>(nullable: true),
                    EmpNote = table.Column<string>(nullable: true),
                    MgrNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRequisitions", x => x.RequisitionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllRequisitions");
        }
    }
}
