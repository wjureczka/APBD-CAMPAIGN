using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class AddPasswordToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 29, 31, 194, DateTimeKind.Local).AddTicks(8125), new DateTime(2020, 6, 11, 15, 29, 31, 187, DateTimeKind.Local).AddTicks(5113) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 14, 50, 2, 225, DateTimeKind.Local).AddTicks(1935), new DateTime(2020, 6, 11, 14, 50, 2, 217, DateTimeKind.Local).AddTicks(7312) });
        }
    }
}
