using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
    public partial class Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceCalculation_Projects_ProjectId",
                table: "PriceCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceCalculation_Services_ServiceId",
                table: "PriceCalculation");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "PriceCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "PriceCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCalculation_Projects_ProjectId",
                table: "PriceCalculation",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCalculation_Services_ServiceId",
                table: "PriceCalculation",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceCalculation_Projects_ProjectId",
                table: "PriceCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceCalculation_Services_ServiceId",
                table: "PriceCalculation");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "PriceCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "PriceCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCalculation_Projects_ProjectId",
                table: "PriceCalculation",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCalculation_Services_ServiceId",
                table: "PriceCalculation",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
