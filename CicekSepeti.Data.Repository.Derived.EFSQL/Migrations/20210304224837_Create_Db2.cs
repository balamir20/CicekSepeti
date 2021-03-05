using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Migrations
{
    public partial class Create_Db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                schema: "Product",
                table: "Product",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                schema: "Product",
                table: "Product",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                schema: "Customer",
                table: "Customer",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                schema: "Customer",
                table: "Customer",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                schema: "Basket",
                table: "Basket",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                schema: "Basket",
                table: "Basket",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                schema: "Basket",
                table: "Basket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "Basket",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                schema: "Product",
                table: "Product",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                schema: "Product",
                table: "Product",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                schema: "Customer",
                table: "Customer",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                schema: "Customer",
                table: "Customer",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                schema: "Basket",
                table: "Basket",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                schema: "Basket",
                table: "Basket",
                newName: "CreateTime");
        }
    }
}
