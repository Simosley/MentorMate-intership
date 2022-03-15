using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOApi.Data.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItemsPriority",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemsPriority", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StatusEnum = table.Column<int>(type: "int", nullable: false),
                    TodoItemPriorityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoItemsPriority_TodoItemPriorityId",
                        column: x => x.TodoItemPriorityId,
                        principalTable: "TodoItemsPriority",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoItemsPriority",
                columns: new[] { "PriorityId", "Title" },
                values: new object[] { 1, "Low" });

            migrationBuilder.InsertData(
                table: "TodoItemsPriority",
                columns: new[] { "PriorityId", "Title" },
                values: new object[] { 2, "Medium" });

            migrationBuilder.InsertData(
                table: "TodoItemsPriority",
                columns: new[] { "PriorityId", "Title" },
                values: new object[] { 3, "High" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoItemPriorityId",
                table: "TodoItems",
                column: "TodoItemPriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoItemsPriority");
        }
    }
}
