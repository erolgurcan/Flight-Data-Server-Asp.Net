using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flightdataserver.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airliner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlinerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlinerCallSign = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airliner", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Airliner",
                columns: new[] { "Id", "AirlinerCallSign", "AirlinerName" },
                values: new object[] { 1, "THY", "Turkish Airliner" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airliner");
        }
    }
}
