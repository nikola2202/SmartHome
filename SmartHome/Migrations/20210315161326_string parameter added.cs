using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class stringparameteradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumberParameter_NumberParameter_NumberParameterId1",
                table: "NumberParameter");

            migrationBuilder.DropIndex(
                name: "IX_NumberParameter_NumberParameterId1",
                table: "NumberParameter");

            migrationBuilder.DropColumn(
                name: "NumberParameterId1",
                table: "NumberParameter");

            migrationBuilder.AddColumn<long>(
                name: "DeviceId",
                table: "NumberParameter",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "StringParameter",
                columns: table => new
                {
                    StringParameterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StringParameterName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StringParameterValue = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringParameter", x => x.StringParameterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumberParameter_DeviceId",
                table: "NumberParameter",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_NumberParameter_Device_DeviceId",
                table: "NumberParameter",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumberParameter_Device_DeviceId",
                table: "NumberParameter");

            migrationBuilder.DropTable(
                name: "StringParameter");

            migrationBuilder.DropIndex(
                name: "IX_NumberParameter_DeviceId",
                table: "NumberParameter");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "NumberParameter");

            migrationBuilder.AddColumn<long>(
                name: "NumberParameterId1",
                table: "NumberParameter",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NumberParameter_NumberParameterId1",
                table: "NumberParameter",
                column: "NumberParameterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_NumberParameter_NumberParameter_NumberParameterId1",
                table: "NumberParameter",
                column: "NumberParameterId1",
                principalTable: "NumberParameter",
                principalColumn: "NumberParameterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
