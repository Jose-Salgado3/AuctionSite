using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionSite.Data.Migrations
{
    public partial class product_PostDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "Product");

            migrationBuilder.AlterColumn<byte>(
                name: "Image",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
