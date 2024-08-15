using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class bsjkdJF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBooking_Hotel_HotelId",
                table: "HotelBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Hotel_HotelId",
                table: "HotelReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelReview",
                table: "HotelReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab282ef-27c7-4fba-b849-770bb327f329");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32d449d-d43c-4bb3-b03d-c436ec87d77c");

            migrationBuilder.RenameTable(
                name: "HotelReview",
                newName: "HotelReviews");

            migrationBuilder.RenameTable(
                name: "HotelBooking",
                newName: "HotelBookings");

            migrationBuilder.RenameIndex(
                name: "IX_HotelReview_HotelId",
                table: "HotelReviews",
                newName: "IX_HotelReviews_HotelId");

            migrationBuilder.RenameColumn(
                name: "CheckedOut",
                table: "HotelBookings",
                newName: "Checkout");

            migrationBuilder.RenameColumn(
                name: "CheckedIn",
                table: "HotelBookings",
                newName: "Checkin");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBooking_HotelId",
                table: "HotelBookings",
                newName: "IX_HotelBookings_HotelId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "HotelBookings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "HotelBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "HotelBookings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HotelBookings",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelReviews",
                table: "HotelReviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e12e5f8-55b2-4496-a388-e05ab6be9e2b", null, "User", "USER" },
                    { "811f1214-f6e6-447b-b628-282855848a30", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_UserId",
                table: "HotelBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_AspNetUsers_UserId",
                table: "HotelBookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Hotel_HotelId",
                table: "HotelBookings",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReviews_Hotel_HotelId",
                table: "HotelReviews",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_AspNetUsers_UserId",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Hotel_HotelId",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelReviews_Hotel_HotelId",
                table: "HotelReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelReviews",
                table: "HotelReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_UserId",
                table: "HotelBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e12e5f8-55b2-4496-a388-e05ab6be9e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f1214-f6e6-447b-b628-282855848a30");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelBookings");

            migrationBuilder.RenameTable(
                name: "HotelReviews",
                newName: "HotelReview");

            migrationBuilder.RenameTable(
                name: "HotelBookings",
                newName: "HotelBooking");

            migrationBuilder.RenameIndex(
                name: "IX_HotelReviews_HotelId",
                table: "HotelReview",
                newName: "IX_HotelReview_HotelId");

            migrationBuilder.RenameColumn(
                name: "Checkout",
                table: "HotelBooking",
                newName: "CheckedOut");

            migrationBuilder.RenameColumn(
                name: "Checkin",
                table: "HotelBooking",
                newName: "CheckedIn");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBooking",
                newName: "IX_HotelBooking_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelReview",
                table: "HotelReview",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bab282ef-27c7-4fba-b849-770bb327f329", null, "Admin", "ADMIN" },
                    { "c32d449d-d43c-4bb3-b03d-c436ec87d77c", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBooking_Hotel_HotelId",
                table: "HotelBooking",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Hotel_HotelId",
                table: "HotelReview",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
