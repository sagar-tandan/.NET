using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Hotel_HotelId",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Users_UserId",
                table: "HotelBookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_UserId",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelBookings");

            migrationBuilder.RenameTable(
                name: "HotelBookings",
                newName: "HotelBooking");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBooking",
                newName: "IX_HotelBooking_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10239295-a6a2-440a-99f9-8f388784a1bc", null, "User", "USER" },
                    { "d53be67a-1b9d-4fb5-b27d-d73806afc0aa", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBooking_Hotel_HotelId",
                table: "HotelBooking",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBooking_Hotel_HotelId",
                table: "HotelBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10239295-a6a2-440a-99f9-8f388784a1bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53be67a-1b9d-4fb5-b27d-d73806afc0aa");

            migrationBuilder.RenameTable(
                name: "HotelBooking",
                newName: "HotelBookings");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBooking_HotelId",
                table: "HotelBookings",
                newName: "IX_HotelBookings_HotelId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HotelBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_UserId",
                table: "HotelBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Hotel_HotelId",
                table: "HotelBookings",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Users_UserId",
                table: "HotelBookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
