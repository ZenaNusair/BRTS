using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRTS_System.Migrations
{
    /// <inheritdoc />
    public partial class FM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    captainname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberofSeats = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus", x => x.BusID);
                    table.ForeignKey(
                        name: "FK_bus_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_trip_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trip_bus_BusID",
                        column: x => x.BusID,
                        principalTable: "bus",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateTable(
                name: "user_trip",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    passengerID = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_trip", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_user_trip_trip_TripId",
                        column: x => x.TripId,
                        principalTable: "trip",
                        principalColumn: "TripID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_trip_user_passengerID",
                        column: x => x.passengerID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_username",
                table: "admin",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bus_AdminID",
                table: "bus",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_bus_captainname",
                table: "bus",
                column: "captainname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trip_AdminId",
                table: "trip",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_trip_BusID",
                table: "trip",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_user_Username",
                table: "user",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_trip_passengerID",
                table: "user_trip",
                column: "passengerID");

            migrationBuilder.CreateIndex(
                name: "IX_user_trip_TripId",
                table: "user_trip",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_trip");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "admin");
        }
    }
}
