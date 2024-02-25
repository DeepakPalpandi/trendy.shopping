using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trendy.shopping.api.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "master",
                table: "state");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                schema: "master",
                table: "state");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "master",
                table: "state");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "master",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                schema: "master",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "master",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "master",
                table: "city");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                schema: "master",
                table: "city");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "master",
                table: "city");

            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "customers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sex",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                schema: "master",
                table: "state",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                schema: "master",
                table: "state",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 110);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                schema: "master",
                table: "state",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "customers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "customers",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 110);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "customers",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                schema: "master",
                table: "countries",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                schema: "master",
                table: "countries",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 110);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                schema: "master",
                table: "countries",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                schema: "master",
                table: "city",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                schema: "master",
                table: "city",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 110);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                schema: "master",
                table: "city",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.UpdateData(
                schema: "master",
                table: "city",
                keyColumn: "id",
                keyValue: new Guid("8c4e2369-534f-44ae-a201-f40f14ced860"),
                columns: new[] { "created_by", "deleted_by", "updated_by" },
                values: new object[] { 0, null, null });

            migrationBuilder.UpdateData(
                schema: "master",
                table: "city",
                keyColumn: "id",
                keyValue: new Guid("e0c26a51-536f-4259-8377-f41916fe1f9a"),
                columns: new[] { "created_by", "deleted_by", "updated_by" },
                values: new object[] { 0, null, null });

            migrationBuilder.UpdateData(
                schema: "master",
                table: "countries",
                keyColumn: "id",
                keyValue: new Guid("e2580151-00dc-466b-9adb-a9329b291286"),
                columns: new[] { "created_by", "deleted_by", "updated_by" },
                values: new object[] { 0, null, null });

            migrationBuilder.UpdateData(
                schema: "master",
                table: "state",
                keyColumn: "id",
                keyValue: new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"),
                columns: new[] { "created_by", "deleted_by", "updated_by" },
                values: new object[] { 0, null, null });
        }
    }
}
