using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store_management_api.Migrations
{
    public partial class initialSTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ExpDate = table.Column<bool>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UbicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Ubicaciones_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "Role" },
                values: new object[] { 1, "ac1@gmail.com", "canapino", "agustin", "12b03226a6d8be9c6e8cd5e55dc6c7920caaa39df14aab92d5e3ea9340d1c8a4d3d0b8e4314f1f6ef131ba4bf1ceb9186ab87c801af0d5c95b1befb8cedae2b9", "Deposito" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "Role" },
                values: new object[] { 2, "rc@gmail.com", "carlos", "roberto", "12b03226a6d8be9c6e8cd5e55dc6c7920caaa39df14aab92d5e3ea9340d1c8a4d3d0b8e4314f1f6ef131ba4bf1ceb9186ab87c801af0d5c95b1befb8cedae2b9", "Deposito" });

            migrationBuilder.InsertData(
                table: "Ubicaciones",
                columns: new[] { "Id", "ExpDate", "NameLocation", "UsuarioId" },
                values: new object[] { 1, false, "250cc", 1 });

            migrationBuilder.InsertData(
                table: "Ubicaciones",
                columns: new[] { "Id", "ExpDate", "NameLocation", "UsuarioId" },
                values: new object[] { 2, true, "150cc", 2 });

            migrationBuilder.InsertData(
                table: "Ubicaciones",
                columns: new[] { "Id", "ExpDate", "NameLocation", "UsuarioId" },
                values: new object[] { 3, false, "600cc", 1 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "EntryDate", "ExpDate", "Name", "Price", "Quantity", "UbicacionId" },
                values: new object[] { 1, new DateTime(2100, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha r6 600cc ", 60700, 7, 3 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "EntryDate", "ExpDate", "Name", "Price", "Quantity", "UbicacionId" },
                values: new object[] { 2, new DateTime(2100, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda tornado 250cc ", 5000, 20, 1 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "EntryDate", "ExpDate", "Name", "Price", "Quantity", "UbicacionId" },
                values: new object[] { 3, new DateTime(2100, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vespa 150cc ", 3500, 25, 2 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "EntryDate", "ExpDate", "Name", "Price", "Quantity", "UbicacionId" },
                values: new object[] { 4, new DateTime(2100, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda cbr 600cc ", 59600, 10, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UbicacionId",
                table: "Productos",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_UsuarioId",
                table: "Ubicaciones",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
