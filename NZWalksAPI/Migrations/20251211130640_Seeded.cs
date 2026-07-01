using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5aa0232d-1f9b-4187-b008-96efd253ecbb"), "Easy" },
                    { new Guid("b02717f0-4d7f-453c-af23-09dc269fd1b9"), "Hard" },
                    { new Guid("dfbefdbb-6e72-4610-b034-1a09868ce778"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1519926d-7644-4215-b14b-9b6edf908b7e"), "West", "Mountain", "https://cdn.pixabay.com/photo/2025/12/06/07/47/07-47-55-754_1280.jpg" },
                    { new Guid("543b5535-0316-44eb-954c-b4d5b61dadf7"), "Midwest", "East North Central", "https://cdn.pixabay.com/photo/2025/12/08/13/36/portal-10002185_1280.jpg" },
                    { new Guid("9b53ce92-08dd-4f13-8ed7-99c2fe58cfe3"), "South", "South Atlantic", "https://cdn.pixabay.com/photo/2025/12/07/09/01/abstract-9999854_1280.jpg" },
                    { new Guid("d873260b-4231-47e2-8c2c-d174a91155a7"), "Northeast", "Mid-Atlantic", "https://cdn.pixabay.com/photo/2025/12/07/09/01/earth-9999856_1280.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("5aa0232d-1f9b-4187-b008-96efd253ecbb"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("b02717f0-4d7f-453c-af23-09dc269fd1b9"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("dfbefdbb-6e72-4610-b034-1a09868ce778"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("1519926d-7644-4215-b14b-9b6edf908b7e"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("543b5535-0316-44eb-954c-b4d5b61dadf7"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("9b53ce92-08dd-4f13-8ed7-99c2fe58cfe3"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("d873260b-4231-47e2-8c2c-d174a91155a7"));
        }
    }
}
