using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace locaweb_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceivedEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Sender = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Recipient = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    Theme = table.Column<bool>(type: "number(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSentEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUser = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdReceivedEmail = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSentEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteSentEmail_ReceivedEmail_IdReceivedEmail",
                        column: x => x.IdReceivedEmail,
                        principalTable: "ReceivedEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteSentEmail_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Recipient = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "date", nullable: false),
                    SendDate = table.Column<DateTime>(type: "date", nullable: false),
                    Viewed = table.Column<bool>(type: "number(1)", nullable: false),
                    Scheduled = table.Column<bool>(type: "number(1)", nullable: false),
                    IdUser = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentEmail_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrashedEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdReceivedEmail = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdSentEmail = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdUser = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashedEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrashedEmail_ReceivedEmail_IdReceivedEmail",
                        column: x => x.IdReceivedEmail,
                        principalTable: "ReceivedEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrashedEmail_SentEmail_IdSentEmail",
                        column: x => x.IdSentEmail,
                        principalTable: "SentEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrashedEmail_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSentEmail_IdReceivedEmail",
                table: "FavoriteSentEmail",
                column: "IdReceivedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSentEmail_IdUser",
                table: "FavoriteSentEmail",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SentEmail_IdUser",
                table: "SentEmail",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TrashedEmail_IdReceivedEmail",
                table: "TrashedEmail",
                column: "IdReceivedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_TrashedEmail_IdSentEmail",
                table: "TrashedEmail",
                column: "IdSentEmail");

            migrationBuilder.CreateIndex(
                name: "IX_TrashedEmail_IdUser",
                table: "TrashedEmail",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteSentEmail");

            migrationBuilder.DropTable(
                name: "TrashedEmail");

            migrationBuilder.DropTable(
                name: "ReceivedEmail");

            migrationBuilder.DropTable(
                name: "SentEmail");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
