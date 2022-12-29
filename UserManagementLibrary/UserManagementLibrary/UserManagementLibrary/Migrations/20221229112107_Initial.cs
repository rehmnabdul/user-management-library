using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserManagement");

            migrationBuilder.CreateTable(
                name: "um_countries",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "um_genders",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "um_cities",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_um_cities_um_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "UserManagement",
                        principalTable: "um_countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "um_users",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PassportNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassChangeRequired = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_um_users_um_genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "UserManagement",
                        principalTable: "um_genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "um_addresses",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompleteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NearBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_um_addresses_um_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "UserManagement",
                        principalTable: "um_cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_um_addresses_um_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagement",
                        principalTable: "um_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "um_users_auths",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PassHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_um_users_auths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_um_users_auths_um_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagement",
                        principalTable: "um_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_um_addresses_CityId",
                schema: "UserManagement",
                table: "um_addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_um_addresses_UserId",
                schema: "UserManagement",
                table: "um_addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_um_cities_CountryId",
                schema: "UserManagement",
                table: "um_cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_um_countries_Title",
                schema: "UserManagement",
                table: "um_countries",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_um_genders_Title",
                schema: "UserManagement",
                table: "um_genders",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_um_users_CitizenNo",
                schema: "UserManagement",
                table: "um_users",
                column: "CitizenNo",
                unique: true,
                filter: "[CitizenNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_um_users_Email",
                schema: "UserManagement",
                table: "um_users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_um_users_GenderId",
                schema: "UserManagement",
                table: "um_users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_um_users_PassportNo",
                schema: "UserManagement",
                table: "um_users",
                column: "PassportNo",
                unique: true,
                filter: "[PassportNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_um_users_Uid",
                schema: "UserManagement",
                table: "um_users",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_um_users_auths_UserId",
                schema: "UserManagement",
                table: "um_users_auths",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "um_addresses",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "um_users_auths",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "um_cities",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "um_users",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "um_countries",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "um_genders",
                schema: "UserManagement");
        }
    }
}
