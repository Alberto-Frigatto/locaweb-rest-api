using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace locaweb_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrashedEmailWithNUllableAttrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrashedEmail_ReceivedEmail_IdReceivedEmail",
                table: "TrashedEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashedEmail_SentEmail_IdSentEmail",
                table: "TrashedEmail");

            migrationBuilder.AlterColumn<int>(
                name: "IdSentEmail",
                table: "TrashedEmail",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "IdReceivedEmail",
                table: "TrashedEmail",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_TrashedEmail_ReceivedEmail_IdReceivedEmail",
                table: "TrashedEmail",
                column: "IdReceivedEmail",
                principalTable: "ReceivedEmail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrashedEmail_SentEmail_IdSentEmail",
                table: "TrashedEmail",
                column: "IdSentEmail",
                principalTable: "SentEmail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrashedEmail_ReceivedEmail_IdReceivedEmail",
                table: "TrashedEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashedEmail_SentEmail_IdSentEmail",
                table: "TrashedEmail");

            migrationBuilder.AlterColumn<int>(
                name: "IdSentEmail",
                table: "TrashedEmail",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdReceivedEmail",
                table: "TrashedEmail",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashedEmail_ReceivedEmail_IdReceivedEmail",
                table: "TrashedEmail",
                column: "IdReceivedEmail",
                principalTable: "ReceivedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashedEmail_SentEmail_IdSentEmail",
                table: "TrashedEmail",
                column: "IdSentEmail",
                principalTable: "SentEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
