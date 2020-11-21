using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndMore.DataAccess.Migrations
{
    public partial class RenamePrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusUpdateId",
                table: "StatusUpdates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RelationshipId",
                table: "Relationships",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmailAddressId",
                table: "EmailAddresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StatusUpdates",
                newName: "StatusUpdateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Relationships",
                newName: "RelationshipId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmailAddresses",
                newName: "EmailAddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");
        }
    }
}
