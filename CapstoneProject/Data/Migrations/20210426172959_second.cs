using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c3394b6-c454-4001-92ee-c5768501eca0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f58b94b8-bef5-4150-8dab-434213d8f504");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_customers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grass",
                columns: table => new
                {
                    GrassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grass", x => x.GrassID);
                });

            migrationBuilder.CreateTable(
                name: "salespeople",
                columns: table => new
                {
                    SalespersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salespeople", x => x.SalespersonID);
                    table.ForeignKey(
                        name: "FK_salespeople_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    SquareFootage = table.Column<int>(type: "int", nullable: false),
                    GrassID = table.Column<int>(type: "int", nullable: true),
                    IsProjectAreaCleared = table.Column<bool>(type: "bit", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SalespersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_projects_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_Grass_GrassID",
                        column: x => x.GrassID,
                        principalTable: "Grass",
                        principalColumn: "GrassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_salespeople_SalespersonID",
                        column: x => x.SalespersonID,
                        principalTable: "salespeople",
                        principalColumn: "SalespersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteractionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_appointments_projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c34f5647-73f2-4e57-a0f5-3529b0462503", "5a940d58-dea2-4d6b-a7cf-6234d124103d", "Salesperson", "SALESPERSON" },
                    { "27c15953-1652-4987-97f3-6839d623ff25", "eb86d164-5111-405f-8571-2c87cd6039cf", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Grass",
                columns: new[] { "GrassID", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 2.5, "Tall Fescue" },
                    { 2, 3.25, "Bermuda" },
                    { 3, 4.0, "Kentucky Bluegrass" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ProjectID",
                table: "appointments",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_customers_IdentityUserId",
                table: "customers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_CustomerID",
                table: "projects",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_projects_GrassID",
                table: "projects",
                column: "GrassID");

            migrationBuilder.CreateIndex(
                name: "IX_projects_SalespersonID",
                table: "projects",
                column: "SalespersonID");

            migrationBuilder.CreateIndex(
                name: "IX_salespeople_IdentityUserId",
                table: "salespeople",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "Grass");

            migrationBuilder.DropTable(
                name: "salespeople");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c15953-1652-4987-97f3-6839d623ff25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34f5647-73f2-4e57-a0f5-3529b0462503");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c3394b6-c454-4001-92ee-c5768501eca0", "c0df645e-3f2a-4bc7-a440-56088aeb0a80", "Salesperson", "SALESPERSON" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f58b94b8-bef5-4150-8dab-434213d8f504", "39d94223-2787-44d9-90f0-2365fe11c81b", "Customer", "CUSTOMER" });
        }
    }
}
