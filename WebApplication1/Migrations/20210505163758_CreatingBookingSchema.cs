using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CreatingBookingSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "LanEnd",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanStart",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LonEnd",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LonStart",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanEnd",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LanStart",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LonEnd",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LonStart",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Bookings",
                type: "text",
                nullable: true);
        }
    }
}
