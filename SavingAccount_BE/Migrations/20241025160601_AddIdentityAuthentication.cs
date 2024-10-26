using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SavingAccount_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfCard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    IdHistory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Change = table.Column<double>(type: "float", nullable: false),
                    DateTransfer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.IdHistory);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    IdNotification = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.IdNotification);
                });

            migrationBuilder.CreateTable(
                name: "SavingAccount",
                columns: table => new
                {
                    IdSavingAccount = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameOfSavingAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Withdraw = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Deposits = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingAccount", x => x.IdSavingAccount);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoFactorEndable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SecurityStampHash = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: " "),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEndable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Friend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_User_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHistory = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardHistory_Card_IdCard",
                        column: x => x.IdCard,
                        principalTable: "Card",
                        principalColumn: "IdCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardHistory_History_IdHistory",
                        column: x => x.IdHistory,
                        principalTable: "History",
                        principalColumn: "IdHistory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingAccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSavingAccount = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHistory = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingAccountHistory_History_IdHistory",
                        column: x => x.IdHistory,
                        principalTable: "History",
                        principalColumn: "IdHistory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavingAccountHistory_SavingAccount_IdSavingAccount",
                        column: x => x.IdSavingAccount,
                        principalTable: "SavingAccount",
                        principalColumn: "IdSavingAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCard_Card_IdCard",
                        column: x => x.IdCard,
                        principalTable: "Card",
                        principalColumn: "IdCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCard_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdNotification = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification_Notification_IdNotification",
                        column: x => x.IdNotification,
                        principalTable: "Notification",
                        principalColumn: "IdNotification",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotification_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSavingAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdSavingAccount = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavingAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSavingAccount_SavingAccount_IdSavingAccount",
                        column: x => x.IdSavingAccount,
                        principalTable: "SavingAccount",
                        principalColumn: "IdSavingAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavingAccount_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "IdCard", "Balance", "Base64Image", "CardNumber", "DateOpened", "NameOfCard", "TypeCard" },
                values: new object[,]
                {
                    { "1", 1000.0, null, "123456", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa", "Credit" },
                    { "2", 5000.0, null, "789012", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MasterCard", "Debit" },
                    { "3", 5000.0, null, "789045", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ghi No", "Debit" }
                });

            migrationBuilder.InsertData(
                table: "History",
                columns: new[] { "IdHistory", "Change", "DateTransfer", "Note" },
                values: new object[,]
                {
                    { "1", 300.0, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "10", -800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "11", -800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "2", -200.0, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "3", 500.0, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "4", 300.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "5", -300.0, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "6", 800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "7", 800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "8", 800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "9", -800.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "IdNotification", "Content" },
                values: new object[,]
                {
                    { "1", "Content1" },
                    { "2", "Content2" }
                });

            migrationBuilder.InsertData(
                table: "SavingAccount",
                columns: new[] { "IdSavingAccount", "Balance", "DateOpened", "NameOfSavingAccount", "Term" },
                values: new object[,]
                {
                    { "1", 300000.0, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "VKT", "3 months" },
                    { "2", 500000.0, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "VKT", "6 months" },
                    { "3", 500000.0, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "LPT", "6 months" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Base64Image", "BirthDate", "CCCD", "City", "Email", "EmailConfirmed", "Friend", "FullName", "Nation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Province", "SecurityStampHash", "UserIdUser" },
                values: new object[,]
                {
                    { "1", null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "001", "Hà Nội", "john@example.com", true, null, "John Doe", "Việt Nam", "$2a$10$B4BKHIe7D5aVXyceF8fmx.hq/akO3kqqEWHJ9mCQnrPi5P7HhMO7G", "1234567890", true, "Hà Nội", "abc123", null },
                    { "2", null, new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "002", "Hồ Chí Minh", "jane@example.com", true, null, "Jane Smith", "Việt Nam", "$2a$10$B4BKHIe7D5aVXyceF8fmx.hq/akO3kqqEWHJ9mCQnrPi5P7HhMO7G", "0987654321", true, "Hồ Chí Minh", "xyz456", null }
                });

            migrationBuilder.InsertData(
                table: "CardHistory",
                columns: new[] { "Id", "IdCard", "IdHistory" },
                values: new object[,]
                {
                    { 1, "1", "7" },
                    { 2, "1", "8" },
                    { 3, "2", "9" },
                    { 4, "3", "11" }
                });

            migrationBuilder.InsertData(
                table: "SavingAccountHistory",
                columns: new[] { "Id", "IdHistory", "IdSavingAccount" },
                values: new object[,]
                {
                    { 1, "2", "1" },
                    { 2, "5", "1" },
                    { 3, "6", "1" },
                    { 4, "4", "2" },
                    { 5, "10", "3" }
                });

            migrationBuilder.InsertData(
                table: "UserCard",
                columns: new[] { "Id", "IdCard", "IdUser" },
                values: new object[,]
                {
                    { 1, "1", "1" },
                    { 2, "2", "2" },
                    { 3, "3", "1" }
                });

            migrationBuilder.InsertData(
                table: "UserNotification",
                columns: new[] { "Id", "IdNotification", "IdUser" },
                values: new object[,]
                {
                    { 1, "1", "1" },
                    { 2, "2", "2" }
                });

            migrationBuilder.InsertData(
                table: "UserSavingAccount",
                columns: new[] { "Id", "IdSavingAccount", "IdUser" },
                values: new object[,]
                {
                    { 1, "1", "1" },
                    { 2, "2", "1" },
                    { 3, "3", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardHistory_IdCard",
                table: "CardHistory",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardHistory_IdHistory",
                table: "CardHistory",
                column: "IdHistory");

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccountHistory_IdHistory",
                table: "SavingAccountHistory",
                column: "IdHistory");

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccountHistory_IdSavingAccount",
                table: "SavingAccountHistory",
                column: "IdSavingAccount");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserIdUser",
                table: "User",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserCard_IdCard",
                table: "UserCard",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_UserCard_IdUser",
                table: "UserCard",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_IdNotification",
                table: "UserNotification",
                column: "IdNotification");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_IdUser",
                table: "UserNotification",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavingAccount_IdSavingAccount",
                table: "UserSavingAccount",
                column: "IdSavingAccount");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavingAccount_IdUser",
                table: "UserSavingAccount",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardHistory");

            migrationBuilder.DropTable(
                name: "SavingAccountHistory");

            migrationBuilder.DropTable(
                name: "UserCard");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "UserSavingAccount");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "SavingAccount");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
