using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HP.DataAccess.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Mass = table.Column<int>(type: "int", nullable: true),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaveNose = table.Column<bool>(type: "bit", nullable: false),
                    Pet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bright Side" },
                    { 2, "Dark Side" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "BirthYear", "CategoryId", "CharacterId", "CreatedAt", "EyeColor", "Gender", "HairColor", "HaveNose", "Height", "Mass", "Name", "Pet", "SkinColor", "Surname", "UpdatedAt", "Wands" },
                values: new object[,]
                {
                    { 1, 1999, null, 1, null, "Brown", "Male", "Brown", true, 193.0, 90, "Can", "Cat", "White", "İçcan", null, "Dont Have" },
                    { 2, 1980, null, 2, null, "Bright green", "Male", "Jet-black", true, 180.0, 67, "Harry James", "Snowy owl", "Light", "Potter", null, "Harry Potter's Wand, Blackthorn Wand, Draco Malfoy's Wand, Elder Wand" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CategoryId",
                table: "Characters",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
