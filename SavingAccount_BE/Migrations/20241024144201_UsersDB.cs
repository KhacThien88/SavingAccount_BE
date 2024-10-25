using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SavingAccount_BE.Migrations
{
    /// <inheritdoc />
    public partial class UsersDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdHistory = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_History_IdHistory",
                        column: x => x.IdHistory,
                        principalTable: "History",
                        principalColumn: "IdHistory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingAccount",
                columns: table => new
                {
                    IdSavingAccount = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameOfSavingAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdHistory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingAccount", x => x.IdSavingAccount);
                    table.ForeignKey(
                        name: "FK_SavingAccount_History_IdHistory",
                        column: x => x.IdHistory,
                        principalTable: "History",
                        principalColumn: "IdHistory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    IdNotification = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Friend = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdSavingAccount = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                    table.ForeignKey(
                        name: "FK_User_Card_IdCard",
                        column: x => x.IdCard,
                        principalTable: "Card",
                        principalColumn: "IdCard");
                    table.ForeignKey(
                        name: "FK_User_Notification_IdNotification",
                        column: x => x.IdNotification,
                        principalTable: "Notification",
                        principalColumn: "IdNotification");
                    table.ForeignKey(
                        name: "FK_User_SavingAccount_IdSavingAccount",
                        column: x => x.IdSavingAccount,
                        principalTable: "SavingAccount",
                        principalColumn: "IdSavingAccount");
                    table.ForeignKey(
                        name: "FK_User_User_Friend",
                        column: x => x.Friend,
                        principalTable: "User",
                        principalColumn: "Email");
                });

            migrationBuilder.InsertData(
                table: "History",
                columns: new[] { "IdHistory", "Change", "DateTransfer", "Note" },
                values: new object[,]
                {
                    { "1", 300.0, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "2", -200.0, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "3", 500.0, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { "4", 300.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "IdNotification", "Content" },
                values: new object[,]
                {
                    { "1", "Day la VKT" },
                    { "2", "Day la LPT" }
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "IdCard", "Balance", "Base64Image", "CardNumber", "DateOpened", "IdHistory", "NameOfCard", "TypeCard" },
                values: new object[,]
                {
                    { "1", 200000.0, null, "000001", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "The tin dung", "Tin dung" },
                    { "2", 500000.0, null, "000002", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", "The tin dung", "Tin dung" }
                });

            migrationBuilder.InsertData(
                table: "SavingAccount",
                columns: new[] { "IdSavingAccount", "Balance", "DateOpened", "IdHistory", "NameOfSavingAccount", "Term" },
                values: new object[,]
                {
                    { "1", 300000.0, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "VKT", "3 months" },
                    { "2", 500000.0, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "4", "LPT", "6 months" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Base64Image", "BirthDate", "CCCD", "City", "Email", "Friend", "FullName", "IdCard", "IdNotification", "IdSavingAccount", "Nation", "PasswordHash", "PhoneNumber", "Province" },
                values: new object[,]
                {
                    { "1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "215913523", "Quy Nhon", "KTeightop1512@gmail.com", null, "Vo Khac Thien", "1", "1", "1", "Viet Nam", "$2y$10$KBvSdRCHLCo6DHHq5kSiiemIOFbKVAQMVeZr5ulfAPiWpQtSeAYD2", "0905647832", "Binh Dinh" },
                    { "2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "215913524", "Quang Ngai", "lephucthuan8@gmail.com", null, "Le Phuc Thuan", "2", "2", "2", "Viet Nam", "$2y$10$KBvSdRCHLCo6DHHq5kSiiemIOFbKVAQMVeZr5ulfAPiWpQtSeAYD2", "113", "Quang Ngai" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_IdHistory",
                table: "Card",
                column: "IdHistory");

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccount_IdHistory",
                table: "SavingAccount",
                column: "IdHistory");

            migrationBuilder.CreateIndex(
                name: "IX_User_Friend",
                table: "User",
                column: "Friend");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdCard",
                table: "User",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdNotification",
                table: "User",
                column: "IdNotification");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdSavingAccount",
                table: "User",
                column: "IdSavingAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "SavingAccount");

            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
