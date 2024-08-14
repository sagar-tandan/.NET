using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updatelatesr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10239295-a6a2-440a-99f9-8f388784a1bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53be67a-1b9d-4fb5-b27d-d73806afc0aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bab282ef-27c7-4fba-b849-770bb327f329", null, "Admin", "ADMIN" },
                    { "c32d449d-d43c-4bb3-b03d-c436ec87d77c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab282ef-27c7-4fba-b849-770bb327f329");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32d449d-d43c-4bb3-b03d-c436ec87d77c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10239295-a6a2-440a-99f9-8f388784a1bc", null, "User", "USER" },
                    { "d53be67a-1b9d-4fb5-b27d-d73806afc0aa", null, "Admin", "ADMIN" }
                });
        }
    }
}
