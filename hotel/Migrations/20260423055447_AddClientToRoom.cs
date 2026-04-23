using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class AddClientToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Hotel_Room",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Room_ClientId",
                table: "Hotel_Room",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Room_Clients_ClientId",
                table: "Hotel_Room",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Room_Clients_ClientId",
                table: "Hotel_Room");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_Room_ClientId",
                table: "Hotel_Room");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Hotel_Room");
        }
    }
}
