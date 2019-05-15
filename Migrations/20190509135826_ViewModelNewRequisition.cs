using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRV7.Migrations
{
    public partial class ViewModelNewRequisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRequisitionInformation",
                columns: table => new
                {
                    ViewModelNewRequisitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VMNREmpEmployeeId = table.Column<int>(nullable: true),
                    VMNRReqRequisitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequisitionInformation", x => x.ViewModelNewRequisitionId);
                    table.ForeignKey(
                        name: "FK_EmployeeRequisitionInformation_AllEmployees_VMNREmpEmployeeId",
                        column: x => x.VMNREmpEmployeeId,
                        principalTable: "AllEmployees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeRequisitionInformation_AllRequisitions_VMNRReqRequisitionId",
                        column: x => x.VMNRReqRequisitionId,
                        principalTable: "AllRequisitions",
                        principalColumn: "RequisitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequisitionInformation_VMNREmpEmployeeId",
                table: "EmployeeRequisitionInformation",
                column: "VMNREmpEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequisitionInformation_VMNRReqRequisitionId",
                table: "EmployeeRequisitionInformation",
                column: "VMNRReqRequisitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRequisitionInformation");
        }
    }
}
