using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class Recreate : Migration
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
                    IdClient = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => new { x.IdClient, x.Login, x.Email });
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
                    ClientIdClient = table.Column<int>(nullable: true),
                    ClientLogin = table.Column<string>(nullable: true),
                    ClientEmail = table.Column<string>(nullable: true),
                    FromIdBuilding = table.Column<int>(nullable: false),
                    FromBuildingIdBuilding = table.Column<int>(nullable: true),
                    ToIdBuilding = table.Column<int>(nullable: false),
                    ToBuildingIdBuilding = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.IdCampaign);
                    table.ForeignKey(
                        name: "FK_Campaign_Building_FromBuildingIdBuilding",
                        column: x => x.FromBuildingIdBuilding,
                        principalTable: "Building",
                        principalColumn: "IdBuilding",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_Building_ToBuildingIdBuilding",
                        column: x => x.ToBuildingIdBuilding,
                        principalTable: "Building",
                        principalColumn: "IdBuilding",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_Client_ClientIdClient_ClientLogin_ClientEmail",
                        columns: x => new { x.ClientIdClient, x.ClientLogin, x.ClientEmail },
                        principalTable: "Client",
                        principalColumns: new[] { "IdClient", "Login", "Email" },
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
                    IdCampaign = table.Column<int>(nullable: false),
                    CampaignIdCampaign = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.IdAdvertisement);
                    table.ForeignKey(
                        name: "FK_Banner_Campaign_CampaignIdCampaign",
                        column: x => x.CampaignIdCampaign,
                        principalTable: "Campaign",
                        principalColumn: "IdCampaign",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Banner",
                columns: new[] { "IdAdvertisement", "Area", "CampaignIdCampaign", "IdCampaign", "Name", "Price" },
                values: new object[] { 1, 50m, null, 1, 5, 0m });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "IdBuilding", "City", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Warszawa", "Filtrowa", 1 },
                    { 2, "Warszawa", "Filtrowa", 2 }
                });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "IdCampaign", "ClientEmail", "ClientIdClient", "ClientLogin", "EndDate", "FromBuildingIdBuilding", "FromIdBuilding", "IdClient", "PricePerSquareMeter", "StartDate", "ToBuildingIdBuilding", "ToIdBuilding" },
                values: new object[] { 1, null, null, null, new DateTime(2020, 6, 11, 20, 13, 14, 198, DateTimeKind.Local).AddTicks(4840), null, 1, 1, 50m, new DateTime(2020, 6, 11, 20, 13, 14, 191, DateTimeKind.Local).AddTicks(6410), null, 2 });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Login", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { 1, "klient1_login", "klient1@klient.pl", "Klient1", "Klient2", "klient1_password", "123123123" });

            migrationBuilder.CreateIndex(
                name: "IX_Banner_CampaignIdCampaign",
                table: "Banner",
                column: "CampaignIdCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_FromBuildingIdBuilding",
                table: "Campaign",
                column: "FromBuildingIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ToBuildingIdBuilding",
                table: "Campaign",
                column: "ToBuildingIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ClientIdClient_ClientLogin_ClientEmail",
                table: "Campaign",
                columns: new[] { "ClientIdClient", "ClientLogin", "ClientEmail" });
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
