using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_visitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabVisitors_tabRooms_RoomId",
                table: "tabVisitors");

            migrationBuilder.DropIndex(
                name: "IX_tabVisitors_RoomId",
                table: "tabVisitors");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "tabVisitors",
                newName: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Room",
                table: "tabVisitors",
                newName: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tabVisitors_RoomId",
                table: "tabVisitors",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_tabVisitors_tabRooms_RoomId",
                table: "tabVisitors",
                column: "RoomId",
                principalTable: "tabRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
