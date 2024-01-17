using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
             name: "Employees",
             columns: table => new
             {
                 Id = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 Admin = table.Column<bool>(type: "bit", nullable: false),
                 Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 HourRate = table.Column<double>(type: "float", nullable: false),
                 Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 PhoneNo = table.Column<int>(type: "int", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Employes", x => x.Id);
             });

            migrationBuilder.CreateTable(
                name: "FixCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyCost = table.Column<double>(type: "float", nullable: false)
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
                name: "PraiceCalculation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ServiseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FixCost = table.Column<double>(type: "float", nullable: false),
                    ServiseCost = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraiceCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Employes_UserId",
                        column: x => x.UserId,
                        principalTable: "Employes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PraiceCalculation_Servises_ServiseId",
                        column: x => x.ServiseId,
                        principalTable: "Servises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Price_Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PraiceCalculationId = table.Column<int>(type: "int", nullable: true),
                    DefaultPack = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    SecondPack = table.Column<double>(type: "float", nullable: false),
                    ThirdPack = table.Column<double>(type: "float", nullable: false),
                    WinPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Packages_PraiceCalculation_PraiceCalculationId",
                        column: x => x.PraiceCalculationId,
                        principalTable: "PraiceCalculation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_ProjectId",
                table: "PraiceCalculation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_ServiseId",
                table: "PraiceCalculation",
                column: "ServiseId");

            migrationBuilder.CreateIndex(
                name: "IX_PraiceCalculation_UserId",
                table: "PraiceCalculation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Packages_PraiceCalculationId",
                table: "Price_Packages",
                column: "PraiceCalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                 name: "FixCosts");

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
        }
    }
}
