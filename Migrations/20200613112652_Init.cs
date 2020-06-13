using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    IdBuilding = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.IdBuilding);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Login = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    IdCampaign = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PricePerSquareMeter = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    IdClient = table.Column<int>(nullable: false),
                    FromIdBuilding = table.Column<int>(nullable: false),
                    ToIdBuilding = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.IdCampaign);
                    table.ForeignKey(
                        name: "FK_Campaign_Building_FromIdBuilding",
                        column: x => x.FromIdBuilding,
                        principalTable: "Building",
                        principalColumn: "IdBuilding",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_Building_ToIdBuilding",
                        column: x => x.ToIdBuilding,
                        principalTable: "Building",
                        principalColumn: "IdBuilding",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    IdAdvertisement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    IdCampaign = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.IdAdvertisement);
                    table.ForeignKey(
                        name: "FK_Banner_Campaign_IdCampaign",
                        column: x => x.IdCampaign,
                        principalTable: "Campaign",
                        principalColumn: "IdCampaign",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "IdBuilding", "City", "Street", "StreetNumber" },
                values: new object[] { 1, "Warszawa", "Filtrowa", 1 });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "IdBuilding", "City", "Street", "StreetNumber" },
                values: new object[] { 2, "Warszawa", "Filtrowa", 2 });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Login", "Password", "Phone", "RefreshToken" },
                values: new object[] { 1, "klient1@klient.pl", "Klient1", "Klient2", "klient1_login", "klient1_password", "123123123", null });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "IdCampaign", "EndDate", "FromIdBuilding", "IdClient", "PricePerSquareMeter", "StartDate", "ToIdBuilding" },
                values: new object[] { 1, new DateTime(2020, 6, 13, 13, 26, 51, 601, DateTimeKind.Local).AddTicks(252), 1, 1, 50m, new DateTime(2020, 6, 13, 13, 26, 51, 593, DateTimeKind.Local).AddTicks(8025), 2 });

            migrationBuilder.InsertData(
                table: "Banner",
                columns: new[] { "IdAdvertisement", "Area", "IdCampaign", "Name", "Price" },
                values: new object[] { 1, 50m, 1, 5, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Banner_IdCampaign",
                table: "Banner",
                column: "IdCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_FromIdBuilding",
                table: "Campaign",
                column: "FromIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_IdClient",
                table: "Campaign",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ToIdBuilding",
                table: "Campaign",
                column: "ToIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Client",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Login",
                table: "Client",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
