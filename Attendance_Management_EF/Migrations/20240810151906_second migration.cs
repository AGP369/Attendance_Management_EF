using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance_Management_EF.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Attendance",
                newName: "EmpIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmpIdId",
                table: "Attendance",
                column: "EmpIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmpIdId",
                table: "Attendance",
                column: "EmpIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employees_EmpIdId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_EmpIdId",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "EmpIdId",
                table: "Attendance",
                newName: "EmpId");
        }
    }
}
