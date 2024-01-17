using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
             name: "Employees",
             columns: table => new
             {
                 Id = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 PhoneNo = table.Column<int>(type: "int", nullable: false),
                 HourRate = table.Column<double>(type: "float", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Employses", x => x.Id);
             });

            migrationBuilder.CreateTable(
                name: "FixCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyCost = table.Column<double>(type: "float", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixCosts", x => x.Id);
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceCalculation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ServicesId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FixCost = table.Column<double>(type: "float", nullable: false),
                    ServiseCost = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceCalculation_Employees_UserId",
                        column: x => x.UserId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PriceCalculation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PriceCalculation_Servises_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PricePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceCalculationId = table.Column<int>(type: "int", nullable: true),
                    DefaultPack = table.Column<double>(type: "float", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    SecondPack = table.Column<double>(type: "float", nullable: false),
                    ThirdPack = table.Column<double>(type: "float", nullable: false),
                    ProfitRatio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Packages_PriceCalculation_PriceCalculationId",
                        column: x => x.PriceCalculationId,
                        principalTable: "PriceCalculation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceCalculation_ProjectId",
                table: "PriceCalculation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceCalculation_ServicesId",
                table: "PriceCalculation",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceCalculation_UserId",
                table: "PriceCalculation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Packages_PriceCalculationId",
                table: "PricePackages",
                column: "PriceCalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                 name: "FixCosts");

            migrationBuilder.DropTable(
                name: "PricePackages");

            migrationBuilder.DropTable(
                name: "PriceCalculation");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
