using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkApp1.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    Distance = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Distinguishments = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Information = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AmountOfPlaces = table.Column<long>(type: "INTEGER", nullable: true),
                    GeneralAmountOfPlaces = table.Column<long>(type: "INTEGER", nullable: true),
                    IsTaken = table.Column<long>(type: "INTEGER", nullable: true),
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TakenFlights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<long>(type: "INTEGER", nullable: true),
                    UserIdCheck = table.Column<long>(type: "INTEGER", nullable: true),
                    FlightId = table.Column<long>(type: "INTEGER", nullable: true),
                    CityName = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakenFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Phone_number = table.Column<long>(type: "INTEGER", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    UserTakenTickets = table.Column<long>(type: "INTEGER", nullable: true),
                    Passport_Id = table.Column<long>(type: "INTEGER", nullable: true),
                    Passport_Series = table.Column<long>(type: "INTEGER", nullable: true),
                    Fullname = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Citizenship = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TakenFlights_UserTakenTickets",
                        column: x => x.UserTakenTickets,
                        principalTable: "TakenFlights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CountryId",
                table: "Flights",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenFlights_FlightId",
                table: "TakenFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenFlights_UserIdCheck",
                table: "TakenFlights",
                column: "UserIdCheck");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTakenTickets",
                table: "Users",
                column: "UserTakenTickets");

            migrationBuilder.AddForeignKey(
                name: "FK_TakenFlights_Users_UserIdCheck",
                table: "TakenFlights",
                column: "UserIdCheck",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Country_CountryId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_TakenFlights_Flights_FlightId",
                table: "TakenFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_TakenFlights_Users_UserIdCheck",
                table: "TakenFlights");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TakenFlights");
        }
    }
}
