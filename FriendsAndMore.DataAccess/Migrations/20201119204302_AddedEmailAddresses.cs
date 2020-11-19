using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndMore.DataAccess.Migrations
{
    public partial class AddedEmailAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.EmailAddressId);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailAddresses",
                columns: new[] { "EmailAddressId", "ContactId", "Email", "Type" },
                values: new object[] { 1, 1, "max@mustermann.de", "private" });

            migrationBuilder.InsertData(
                table: "EmailAddresses",
                columns: new[] { "EmailAddressId", "ContactId", "Email", "Type" },
                values: new object[] { 2, 2, "manuela@mustermann.de", "private" });

            migrationBuilder.InsertData(
                table: "EmailAddresses",
                columns: new[] { "EmailAddressId", "ContactId", "Email", "Type" },
                values: new object[] { 3, 3, "john.smith@ee-mail.de", "private" });

            migrationBuilder.InsertData(
                table: "EmailAddresses",
                columns: new[] { "EmailAddressId", "ContactId", "Email", "Type" },
                values: new object[] { 4, 1, "max@enterprise-stuff.de", "work" });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_ContactId",
                table: "EmailAddresses",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddresses");
        }
    }
}
