using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class Updatedtablesauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491e94c1-5371-4031-be69-2ea10a22aebb",
                column: "NormalizedName",
                value: "Writer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491e94c1-5371-4031-be69-2ea10a22aebb",
                column: "NormalizedName",
                value: null);
        }
    }
}
