using Microsoft.EntityFrameworkCore.Migrations;

namespace WheresTheBread.Data.Migrations
{
    public partial class updatedDataTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubActivityItems",
                columns: table => new
                {
                    SubActivityId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubActivityItems", x => new { x.SubActivityId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_SubActivityItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubActivityItems_SubActivities_SubActivityId",
                        column: x => x.SubActivityId,
                        principalTable: "SubActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubActivities_ActivityId",
                table: "SubActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubActivityItems_ItemId",
                table: "SubActivityItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubActivityItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SubActivities");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
