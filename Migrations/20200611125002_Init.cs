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
                    Login = table.Column<string>(maxLength: 100, nullable: true)
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
                    ClientIdClient = table.Column<int>(nullable: true),
                    FromIdBuilding = table.Column<int>(nullable: false),
                    FromBuildingIdBuilding = table.Column<int>(nullable: true),
                    ToIdBuilding = table.Column<int>(nullable: false),
                    ToBuildingIdBuilding = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.IdCampaign);
                    table.ForeignKey(
                        name: "FK_Campaign_Client_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "IdCampaign", "ClientIdClient", "EndDate", "FromBuildingIdBuilding", "FromIdBuilding", "IdClient", "PricePerSquareMeter", "StartDate", "ToBuildingIdBuilding", "ToIdBuilding" },
                values: new object[] { 1, null, new DateTime(2020, 6, 11, 14, 50, 2, 225, DateTimeKind.Local).AddTicks(1935), null, 1, 1, 50m, new DateTime(2020, 6, 11, 14, 50, 2, 217, DateTimeKind.Local).AddTicks(7312), null, 2 });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Login", "Phone" },
                values: new object[] { 1, "klient1@klient.pl", "Klient1", "Klient2", "klient1_login", null });

            migrationBuilder.CreateIndex(
                name: "IX_Banner_CampaignIdCampaign",
                table: "Banner",
                column: "CampaignIdCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ClientIdClient",
                table: "Campaign",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_FromBuildingIdBuilding",
                table: "Campaign",
                column: "FromBuildingIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ToBuildingIdBuilding",
                table: "Campaign",
                column: "ToBuildingIdBuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
