using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndMore.DataAccess.Migrations
{
    public partial class AddIsFavoriteToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Contacts");
        }
    }
}
