using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
    public partial class DBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "FixCosts",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     monthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                     Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                     lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                     Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_FixCosts", x => x.Id);
                 });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                });



            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servises",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PraiceCalculation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeidId = table.Column<int>(type: "int", nullable: true),
                    Serviseidid = table.Column<int>(type: "int", nullable: true),
                    ProjectidId = table.Column<int>(type: "int", nullable: true),
                    ServiseCost = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    fixCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraiceCalculation", x => x.id);
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Employes_EmployeidId",
                        column: x => x.EmployeidId,
                        principalTable: "Employes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Projects_ProjectidId",
                        column: x => x.ProjectidId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Servises_Serviseidid",
                        column: x => x.Serviseidid,
                        principalTable: "Servises",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Price_Packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PraiceCalculationIDid = table.Column<int>(type: "int", nullable: true),
                    winperc = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false),
                    defaultpack = table.Column<double>(type: "float", nullable: false),
                    secondpack = table.Column<double>(type: "float", nullable: false),
                    thirdpack = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Packages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Price_Packages_PraiceCalculation_PraiceCalculationIDid",
                        column: x => x.PraiceCalculationIDid,
                        principalTable: "PraiceCalculation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_EmployeidId",
                table: "PraiceCalculation",
                column: "EmployeidId");

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_ProjectidId",
                table: "PraiceCalculation",
                column: "ProjectidId");

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_Serviseidid",
                table: "PraiceCalculation",
                column: "Serviseidid");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Packages_PraiceCalculationIDid",
                table: "Price_Packages",
                column: "PraiceCalculationIDid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price_Packages");

            migrationBuilder.DropTable(
                name: "PraiceCalculation");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Servises");

            migrationBuilder.DropTable(
            name: "FixCosts");
        }
    }
}
