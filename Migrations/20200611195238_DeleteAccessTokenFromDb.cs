using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class DeleteAccessTokenFromDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 21, 52, 38, 455, DateTimeKind.Local).AddTicks(8885), new DateTime(2020, 6, 11, 21, 52, 38, 449, DateTimeKind.Local).AddTicks(6032) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 21, 40, 54, 720, DateTimeKind.Local).AddTicks(6358), new DateTime(2020, 6, 11, 21, 40, 54, 714, DateTimeKind.Local).AddTicks(7248) });
        }
    }
}
