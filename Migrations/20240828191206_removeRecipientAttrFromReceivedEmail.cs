using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace locaweb_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class removeRecipientAttrFromReceivedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "ReceivedEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "ReceivedEmail",
                type: "NVARCHAR2(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
