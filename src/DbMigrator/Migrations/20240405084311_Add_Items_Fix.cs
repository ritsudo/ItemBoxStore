using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemBoxStore.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_Items_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Files");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Items",
                type: "uuid",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Items",
                type: "integer",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Files",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
