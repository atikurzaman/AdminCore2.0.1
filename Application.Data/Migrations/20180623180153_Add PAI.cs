using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class AddPAI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProductAttributeItem",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ProductAttributeItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductAttributeItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ProductAttributeItem",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "ProductAttributeItem",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "ProductAttributeItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProductAttributeItem",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProductAttribute",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ProductAttribute",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductAttribute",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ProductAttribute",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "ProductAttribute",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "ProductAttribute",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProductAttribute",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProductAttributeItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProductAttribute");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProductAttributeItem",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProductAttribute",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
