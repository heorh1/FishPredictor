using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishPredictor.DB.Migrations
{
    /// <inheritdoc />
    public partial class SeedFishData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureMin = table.Column<double>(type: "float", nullable: false),
                    TemperatureMax = table.Column<double>(type: "float", nullable: false),
                    PressureMin = table.Column<double>(type: "float", nullable: false),
                    PressureMax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "Id", "Name", "PressureMax", "PressureMin", "TemperatureMax", "TemperatureMin" },
                values: new object[,]
                {
                    { 1, "Bream", 800.0, 700.0, 30.0, -25.0 },
                    { 2, "Carp", 800.0, 750.0, 30.0, 0.0 },
                    { 3, "Roach", 800.0, 720.0, 30.0, -20.0 },
                    { 4, "Perch", 800.0, 760.0, 30.0, -20.0 },
                    { 5, "Catfish", 780.0, 750.0, 30.0, 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fishes");
        }
    }
}
