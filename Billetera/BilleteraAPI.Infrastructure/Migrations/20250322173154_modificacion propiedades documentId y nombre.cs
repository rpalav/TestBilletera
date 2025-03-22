using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modificacionpropiedadesdocumentIdynombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Billeteras",
                type: "varchar(65)",
                unicode: false,
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "Billeteras",
                type: "varchar(25)",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Billeteras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(65)",
                oldUnicode: false,
                oldMaxLength: 65);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "Billeteras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldUnicode: false,
                oldMaxLength: 25);
        }
    }
}
