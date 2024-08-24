using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace locaweb_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCanceledAttrToSentEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "SentEmail",
                type: "number(1)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "SentEmail");
        }
    }
}
