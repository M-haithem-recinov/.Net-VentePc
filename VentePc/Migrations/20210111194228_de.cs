using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentePc.Migrations
{
    public partial class de : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactClient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Vente",
                columns: table => new
                {
                    VenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduiId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vente", x => x.VenteId);
                    table.ForeignKey(
                        name: "FK_Vente_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vente_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vente_ClientId",
                table: "Vente",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vente_ProduitId",
                table: "Vente",
                column: "ProduitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vente");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
