using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace trendy.shopping.api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deleted_by = table.Column<int>(type: "integer", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    country_name = table.Column<string>(type: "text", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deleted_by = table.Column<int>(type: "integer", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<string>(type: "text", nullable: false),
                    alias = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deleted_by = table.Column<int>(type: "integer", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_name = table.Column<string>(type: "text", nullable: false),
                    state_code = table.Column<string>(type: "text", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_state", x => x.id);
                    table.ForeignKey(
                        name: "fk_state_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "master",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    customers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_line1 = table.Column<string>(type: "text", nullable: false),
                    address_line2 = table.Column<string>(type: "text", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: true),
                    pin_code = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_customer_addresses_customers_customers_id",
                        column: x => x.customers_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deleted_by = table.Column<int>(type: "integer", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    city_code = table.Column<string>(type: "text", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_state_state_id",
                        column: x => x.state_id,
                        principalSchema: "master",
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "master",
                table: "countries",
                columns: new[] { "id", "country_code", "country_name", "created_at", "created_by", "created_ip", "deleted_at", "deleted_by", "deleted_ip", "is_active", "is_deleted", "sequence", "updated_at", "updated_by", "updated_ip" },
                values: new object[] { new Guid("e2580151-00dc-466b-9adb-a9329b291286"), "india", "India", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "", null, null, null, true, false, 1, null, null, null });

            migrationBuilder.InsertData(
                schema: "master",
                table: "state",
                columns: new[] { "id", "country_id", "created_at", "created_by", "created_ip", "deleted_at", "deleted_by", "deleted_ip", "is_active", "is_deleted", "sequence", "state_code", "state_name", "updated_at", "updated_by", "updated_ip" },
                values: new object[] { new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"), new Guid("e2580151-00dc-466b-9adb-a9329b291286"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "", null, null, null, true, false, 1, "tamil_nadu", "TamilNadu", null, null, null });

            migrationBuilder.InsertData(
                schema: "master",
                table: "city",
                columns: new[] { "id", "city_code", "city_name", "created_at", "created_by", "created_ip", "deleted_at", "deleted_by", "deleted_ip", "is_active", "is_deleted", "sequence", "state_id", "updated_at", "updated_by", "updated_ip" },
                values: new object[,]
                {
                    { new Guid("8c4e2369-534f-44ae-a201-f40f14ced860"), "madurai", "Maduari", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "", null, null, null, true, false, 2, new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"), null, null, null },
                    { new Guid("e0c26a51-536f-4259-8377-f41916fe1f9a"), "chennai", "Chennai", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "", null, null, null, true, false, 1, new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"), null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_city_city_name",
                schema: "master",
                table: "city",
                column: "city_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_city_state_id",
                schema: "master",
                table: "city",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_countries_country_name",
                schema: "master",
                table: "countries",
                column: "country_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_addresses_customers_id",
                table: "customer_addresses",
                column: "customers_id");

            migrationBuilder.CreateIndex(
                name: "ix_state_country_id",
                schema: "master",
                table: "state",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_state_state_name",
                schema: "master",
                table: "state",
                column: "state_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city",
                schema: "master");

            migrationBuilder.DropTable(
                name: "customer_addresses");

            migrationBuilder.DropTable(
                name: "state",
                schema: "master");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "master");
        }
    }
}
