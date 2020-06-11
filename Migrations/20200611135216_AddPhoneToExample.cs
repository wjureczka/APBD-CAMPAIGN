using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_CAMPAIGN.Migrations
{
    public partial class AddPhoneToExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 52, 16, 476, DateTimeKind.Local).AddTicks(3757), new DateTime(2020, 6, 11, 15, 52, 16, 469, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Phone",
                value: "123123123");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Phone",
                value: null);
        }
    }
}
