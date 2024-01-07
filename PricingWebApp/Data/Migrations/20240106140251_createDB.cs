using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
	public partial class createDB : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			   migrationBuilder.CreateTable(
				name: "Services",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Title = table.Column<string>(maxLength: 256, nullable: false),
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Service", x => x.Id);
				});
				
				   migrationBuilder.CreateTable(
				name: "Projects",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Title = table.Column<string>(maxLength: 256, nullable: false),
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Project", x => x.Id);
				});
				
				migrationBuilder.CreateTable(
				name: "Fix_costs",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Title = table.Column<string>(maxLength: 256, nullable: false),
					Last_update = table.Column<DateTimeOffset>(nullable: true),
					Monthly_cost = table.Column<bool>(nullable: true),
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Fix_cost", x => x.Id);
				});
				
				migrationBuilder.CreateTable(
				name: "Employees",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Name = table.Column<string>(maxLength: 256, nullable: false),
					Section = table.Column<string>(maxLength: 256, nullable: false),
					Hour_rate = table.Column<bool>( nullable: false),
				
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Employee", x => x.Id);
				});
				
						migrationBuilder.CreateTable(
				name: "Price_calculation",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
				  	ProjectId = table.Column<string>(nullable: false),
					ServiceId = table.Column<string>(nullable: false),
					EmployeeId = table.Column<string>(nullable: false),
					Service_cost = table.Column<bool>( nullable: false),
					count = table.Column<int>( nullable: false),
					fix_cost = table.Column<bool>( nullable: false),
				
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Price_calculation", x => x.Id);
					   table.ForeignKey(
						name: "PK_Project",
						column: x => x.ProjectId,
						principalTable: "Projects",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
						
						 table.ForeignKey(
						name: "PK_Service",
						column: x => x.ServiceId,
						principalTable: "Services",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
						
						 table.ForeignKey(
						name: "PK_Employee",
						column: x => x.EmployeeId,
						principalTable: "Employees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});
				
					migrationBuilder.CreateTable(
				name: "Price_packages",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Price_calculation = table.Column<string>(nullable: false),
					WinPerc = table.Column<int>( nullable: false),
					Discount = table.Column<int>( nullable: false),
					DefultePack = table.Column<bool>( nullable: false),
					SecoundPack = table.Column<bool>( nullable: false),
					ThirdPack = table.Column<bool>( nullable: false),
				
				   
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Price_packages", x => x.Id);
						
						 table.ForeignKey(
						name: "PK_Price_calculation",
						column: x => x.Price_calculation,
						principalTable: "Price_calculation",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});


		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
