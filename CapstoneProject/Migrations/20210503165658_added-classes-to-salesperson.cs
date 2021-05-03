using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject.Migrations
{
    public partial class addedclassestosalesperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a684cf5e-5926-48dd-9d1b-aec5fac493f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b69be5a0-0bb6-42e8-b61f-626e5b60d07a");

            migrationBuilder.AddColumn<int>(
                name: "TotalOpportunities",
                table: "Salespeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPossibleSales",
                table: "Salespeople",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalProjects",
                table: "Salespeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSales",
                table: "Salespeople",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a490567d-ac25-4b17-87a8-039c296e8129", "99f5be63-14b8-44ec-8944-db12390a48a4", "Salesperson", "SALESPERSON" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5c4193e-5c9f-4104-90ec-542e958a301d", "d8c30821-cb5c-498b-bbef-d64081378f2d", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a490567d-ac25-4b17-87a8-039c296e8129");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5c4193e-5c9f-4104-90ec-542e958a301d");

            migrationBuilder.DropColumn(
                name: "TotalOpportunities",
                table: "Salespeople");

            migrationBuilder.DropColumn(
                name: "TotalPossibleSales",
                table: "Salespeople");

            migrationBuilder.DropColumn(
                name: "TotalProjects",
                table: "Salespeople");

            migrationBuilder.DropColumn(
                name: "TotalSales",
                table: "Salespeople");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b69be5a0-0bb6-42e8-b61f-626e5b60d07a", "40b15103-77c3-4467-9e87-6ab4f5b72202", "Salesperson", "SALESPERSON" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a684cf5e-5926-48dd-9d1b-aec5fac493f7", "cbb60528-b88a-4e61-90fa-cc241b3ce739", "Customer", "CUSTOMER" });
        }
    }
}
