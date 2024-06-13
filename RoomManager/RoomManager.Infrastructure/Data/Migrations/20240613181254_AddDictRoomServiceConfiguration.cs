using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDictRoomServiceConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DictRoomServices",
                table: "DictRoomServices");

            migrationBuilder.EnsureSchema(
                name: "dict");

            migrationBuilder.RenameTable(
                name: "DictRoomServices",
                newName: "dict_room_service",
                newSchema: "dict");

            migrationBuilder.AlterTable(
                name: "dict_room_service",
                schema: "dict",
                comment: "Справочник удобств в номере");

            migrationBuilder.AlterColumn<int>(
                name: "SerialNumber",
                schema: "dict",
                table: "dict_room_service",
                type: "integer",
                nullable: true,
                comment: "Порядковый номер для отображения",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dict",
                table: "dict_room_service",
                type: "text",
                nullable: false,
                comment: "Название удобства",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dict_room_service",
                schema: "dict",
                table: "dict_room_service",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dict_room_service",
                schema: "dict",
                table: "dict_room_service");

            migrationBuilder.RenameTable(
                name: "dict_room_service",
                schema: "dict",
                newName: "DictRoomServices");

            migrationBuilder.AlterTable(
                name: "DictRoomServices",
                oldComment: "Справочник удобств в номере");

            migrationBuilder.AlterColumn<int>(
                name: "SerialNumber",
                table: "DictRoomServices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Порядковый номер для отображения");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DictRoomServices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Название удобства");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DictRoomServices",
                table: "DictRoomServices",
                column: "Id");
        }
    }
}
