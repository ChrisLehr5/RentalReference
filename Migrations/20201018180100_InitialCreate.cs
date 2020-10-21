using Microsoft.EntityFrameworkCore.Migrations;

namespace ReferenceReferralApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(maxLength: 30, nullable: false),
                    lastName = table.Column<string>(maxLength: 30, nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "email", "firstName", "lastName" },
                values: new object[] { 1, "Brett@email,com", "Brett", "Maiki" });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "email", "firstName", "lastName" },
                values: new object[] { 2, "Brett@email,com", "Brad", "Maiki" });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "email", "firstName", "lastName" },
                values: new object[] { 3, "Brett@email,com", "Sally", "Maiki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "References");
        }
    }
}
