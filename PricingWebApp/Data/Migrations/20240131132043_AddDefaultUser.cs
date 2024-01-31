using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Security;

#nullable disable

namespace PricingWebApp.Data.Migrations
{
    public partial class AddDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "AspNetUsers",
            columns: new[] { 
                "Id",
                "UserName",
                "NormalizedUserName",
                "Email",
                "NormalizedEmail",
                "EmailConfirmed", 
                "PasswordHash", 
                "SecurityStamp", 
                "ConcurrencyStamp", 
                "PhoneNumber", 
                "PhoneNumberConfirmed", 
                "TwoFactorEnabled", 
                "LockoutEnd", 
                "LockoutEnabled", 
                "AccessFailedCount" },
            values: new object[,] {
               {
                    "69acf3d6-475f-4412-818f-19b3b05b06e4",
                    "info@netwitcher.com",
                    "INFO@NETWITCHER.COM",
                    "info@netwitcher.com",
                    "INFO@NETWITCHER.COM",
                    true,
                    "AQAAAAEAACcQAAAAEEt3Bz8o80sOBRSekpHo6aS1IlSyY5YWJAblPsFVJ6fs23D5OIbllCEOqnxTo+Nlqg==",
                    "PVDH6W5BDHZDENIUKFAXOLXJGSTH3CSJ",
                    "a4c0d9bf-17dd-44b3-ac6a-eb2c7edd46d8",
                    null,
                    false,
                    false,
                    null,
                    true,
                    0
               },
           });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserName",
                keyValue: "info@netwitcher.com"
                );
        }
    }
}
