using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CreatingDriverSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverInfo",
                columns: table => new
                {
                    DriverID = table.Column<string>(nullable: false),
                    PassangerCapacity = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    RegistrationPlate = table.Column<string>(nullable: true),
                    WIFI = table.Column<bool>(nullable: false),
                    AirConditioned = table.Column<int>(nullable: false),
                    FoodDrink = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverInfo", x => x.DriverID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverInfo");
        }
    }
}
