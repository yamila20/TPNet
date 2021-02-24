using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.DataBase.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    demora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<double>(type: "float", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    formaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PedidoId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.id);
                    table.ForeignKey(
                        name: "FK_Factura_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    tipo = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    tamaño = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    subTotal = table.Column<double>(type: "float", maxLength: 50, nullable: false),
                    PedidoId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PizzaId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientePizza",
                columns: table => new
                {
                    Ingredienteid = table.Column<int>(type: "int", nullable: false),
                    Pizzaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePizza", x => new { x.Ingredienteid, x.Pizzaid });
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Ingrediente_Ingredienteid",
                        column: x => x.Ingredienteid,
                        principalTable: "Ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Pizza_Pizzaid",
                        column: x => x.Pizzaid,
                        principalTable: "Pizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoId",
                table: "DetallePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PizzaId",
                table: "DetallePedido",
                column: "PizzaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PedidoId",
                table: "Factura",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_Pizzaid",
                table: "IngredientePizza",
                column: "Pizzaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "IngredientePizza");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
