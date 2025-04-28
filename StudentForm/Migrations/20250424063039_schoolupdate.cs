using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentForm.Migrations
{
    /// <inheritdoc />
    public partial class schoolupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactNo1",
                table: "Schools",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactNo2",
                table: "Schools",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Schools",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PinCode",
                table: "Schools",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Schools",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Schools",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContactNo1", "ContactNo2", "Email", "PinCode", "State", "TeacherName" },
                values: new object[] { 0, 0, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContactNo1", "ContactNo2", "Email", "PinCode", "State", "TeacherName" },
                values: new object[] { 0, 0, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ContactNo1", "ContactNo2", "Email", "PinCode", "State", "TeacherName" },
                values: new object[] { 0, 0, null, 0, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_DistrictId",
                table: "Centers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_TehsilId",
                table: "Centers",
                column: "TehsilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Districts_DistrictId",
                table: "Centers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Tehsils_TehsilId",
                table: "Centers",
                column: "TehsilId",
                principalTable: "Tehsils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Districts_DistrictId",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Tehsils_TehsilId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_DistrictId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_TehsilId",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "ContactNo1",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "ContactNo2",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Schools");
        }
    }
}
