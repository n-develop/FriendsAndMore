using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndMore.DataAccess.Migrations
{
    public partial class AddedTelephoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelephoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TelephoneNumbers",
                columns: new[] { "Id", "ContactId", "Telephone", "Type" },
                values: new object[] { 1, 1, "555 - 2019383", "Private" });

            migrationBuilder.InsertData(
                table: "TelephoneNumbers",
                columns: new[] { "Id", "ContactId", "Telephone", "Type" },
                values: new object[] { 2, 1, "555 - 77352", "Work" });

            migrationBuilder.InsertData(
                table: "TelephoneNumbers",
                columns: new[] { "Id", "ContactId", "Telephone", "Type" },
                values: new object[] { 3, 2, "555 - 104834", "Private" });

            migrationBuilder.InsertData(
                table: "TelephoneNumbers",
                columns: new[] { "Id", "ContactId", "Telephone", "Type" },
                values: new object[] { 4, 3, "555 - 095237", "Mobile" });

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumbers_ContactId",
                table: "TelephoneNumbers",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelephoneNumbers");
        }
    }
}
