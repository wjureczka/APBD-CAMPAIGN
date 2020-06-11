using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class AddRefreshTokenAndAccessToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Client",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 21, 40, 54, 720, DateTimeKind.Local).AddTicks(6358), new DateTime(2020, 6, 11, 21, 40, 54, 714, DateTimeKind.Local).AddTicks(7248) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 13, 14, 198, DateTimeKind.Local).AddTicks(4840), new DateTime(2020, 6, 11, 20, 13, 14, 191, DateTimeKind.Local).AddTicks(6410) });
        }
    }
}
