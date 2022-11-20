using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWork2.Migrations
{
    public partial class AddCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                table: "person");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "People",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Phonenummer",
                table: "People",
                newName: "PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "CityVMPersonVM",
                columns: table => new
                {
                    citiesName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    peopleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityVMPersonVM", x => new { x.citiesName, x.peopleId });
                    table.ForeignKey(
                        name: "FK_CityVMPersonVM_City_citiesName",
                        column: x => x.citiesName,
                        principalTable: "City",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityVMPersonVM_People_peopleId",
                        column: x => x.peopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Name", "PostNumber" },
                values: new object[,]
                {
                    { "Järpen", "415 44" },
                    { "Åre", "415 55" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "EfterName", "Name", "PhoneNumber", "age" },
                values: new object[,]
                {
                    { "2d3b8d8d-0a91-49e3-9dc7-b27bb73b8a87", "khawari", "Ali", "1245", 32 },
                    { "358c9721-60e9-4094-9a6a-793cace7f8a4", "khawari33", "Ali33", "1245", 32 },
                    { "fae4f872-b5bc-46d6-9e8f-7364bab6babc", "khawari22", "Ali22", "1245", 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityVMPersonVM_peopleId",
                table: "CityVMPersonVM",
                column: "peopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityVMPersonVM");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "2d3b8d8d-0a91-49e3-9dc7-b27bb73b8a87");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "358c9721-60e9-4094-9a6a-793cace7f8a4");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "fae4f872-b5bc-46d6-9e8f-7364bab6babc");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "person");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "person",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "person",
                newName: "Phonenummer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person",
                table: "person",
                column: "Id");
        }
    }
}
