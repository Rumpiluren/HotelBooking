using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF.HotelBooking.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Allinclusive = table.Column<bool>(type: "bit", nullable: false),
                    Breakfast = table.Column<bool>(type: "bit", nullable: false),
                    Transport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Dreamland Circus Hotel", 0 },
                    { 2, "Depressing Shack", 0 },
                    { 3, "The House", 0 },
                    { 4, "Dreamland Shack", 0 },
                    { 5, "Depressing House", 0 },
                    { 6, "Majestic House", 0 },
                    { 7, "Dreamland Coffee Hotel", 0 },
                    { 8, "Royal Coffee Hotel", 0 },
                    { 9, "Royal Circus Hotel", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, "new@gmail.com", "Test", "Hej", null, 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "HotelId", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 13, 1, "Room 13", 0, 0 },
                    { 23, 5, "Room 23", 0, 0 },
                    { 27, 5, "Room 27", 0, 0 },
                    { 38, 5, "Room 38", 0, 0 },
                    { 10, 6, "Room 10", 0, 0 },
                    { 11, 6, "Room 11", 0, 0 },
                    { 12, 6, "Room 12", 0, 0 },
                    { 17, 6, "Room 17", 0, 0 },
                    { 21, 6, "Room 21", 0, 0 },
                    { 22, 6, "Room 22", 0, 0 },
                    { 29, 6, "Room 29", 0, 0 },
                    { 39, 6, "Room 39", 0, 0 },
                    { 48, 6, "Room 48", 0, 0 },
                    { 6, 7, "Room 6", 0, 0 },
                    { 8, 7, "Room 8", 0, 0 },
                    { 28, 7, "Room 28", 0, 0 },
                    { 45, 7, "Room 45", 0, 0 },
                    { 46, 7, "Room 46", 0, 0 },
                    { 1, 8, "Room 1", 0, 0 },
                    { 2, 8, "Room 2", 0, 0 },
                    { 5, 8, "Room 5", 0, 0 },
                    { 24, 8, "Room 24", 0, 0 },
                    { 18, 5, "Room 18", 0, 0 },
                    { 26, 8, "Room 26", 0, 0 },
                    { 4, 5, "Room 4", 0, 0 },
                    { 40, 4, "Room 40", 0, 0 },
                    { 31, 1, "Room 31", 0, 0 },
                    { 34, 1, "Room 34", 0, 0 },
                    { 37, 1, "Room 37", 0, 0 },
                    { 42, 1, "Room 42", 0, 0 },
                    { 43, 1, "Room 43", 0, 0 },
                    { 47, 1, "Room 47", 0, 0 },
                    { 19, 2, "Room 19", 0, 0 },
                    { 30, 2, "Room 30", 0, 0 },
                    { 36, 2, "Room 36", 0, 0 },
                    { 3, 3, "Room 3", 0, 0 },
                    { 9, 3, "Room 9", 0, 0 },
                    { 14, 3, "Room 14", 0, 0 },
                    { 25, 3, "Room 25", 0, 0 },
                    { 41, 3, "Room 41", 0, 0 },
                    { 44, 3, "Room 44", 0, 0 },
                    { 7, 4, "Room 7", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "HotelId", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 15, 4, "Room 15", 0, 0 },
                    { 16, 4, "Room 16", 0, 0 },
                    { 20, 4, "Room 20", 0, 0 },
                    { 32, 4, "Room 32", 0, 0 },
                    { 35, 4, "Room 35", 0, 0 },
                    { 49, 4, "Room 49", 0, 0 },
                    { 33, 8, "Room 33", 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
