using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapIM.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "431, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Floor = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Block = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "301, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 255, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professor_Room",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_Slug",
                table: "Departments",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_Slug",
                table: "Professors",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professors_DepartmentId",
                table: "Professors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_RoomId",
                table: "Professors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Slug",
                table: "Rooms",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DepartmentId",
                table: "Rooms",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
