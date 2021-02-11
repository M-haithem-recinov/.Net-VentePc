using Microsoft.EntityFrameworkCore.Migrations;

namespace VentePc.Migrations
{
    public partial class degg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vente_Produits_ProduitId",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "ProduiId",
                table: "Vente");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitId",
                table: "Vente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_Produits_ProduitId",
                table: "Vente",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "ProduitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vente_Produits_ProduitId",
                table: "Vente");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitId",
                table: "Vente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProduiId",
                table: "Vente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_Produits_ProduitId",
                table: "Vente",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "ProduitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
