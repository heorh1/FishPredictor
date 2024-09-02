using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishPredictor.DB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFishPressureData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 1010.0, 1005.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 1007.0, 1003.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 1015.0, 1001.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 1010.0, 1007.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 1014.0, 1000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 800.0, 700.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 800.0, 750.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 800.0, 720.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 800.0, 760.0 });

            migrationBuilder.UpdateData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PressureMax", "PressureMin" },
                values: new object[] { 780.0, 750.0 });
        }
    }
}
