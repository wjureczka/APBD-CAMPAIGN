using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class AddPasswordToClientWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 31, 10, 687, DateTimeKind.Local).AddTicks(1501), new DateTime(2020, 6, 11, 15, 31, 10, 680, DateTimeKind.Local).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "klient1_password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 29, 31, 194, DateTimeKind.Local).AddTicks(8125), new DateTime(2020, 6, 11, 15, 29, 31, 187, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: null);
        }
    }
}
