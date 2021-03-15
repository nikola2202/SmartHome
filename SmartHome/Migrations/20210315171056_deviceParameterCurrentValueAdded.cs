using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class deviceParameterCurrentValueAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceParameterCurrentValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StringParameterId = table.Column<long>(type: "bigint", nullable: false),
                    NumberParameterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParameterCurrentValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceParameterCurrentValue_NumberParameter_NumberParameterId",
                        column: x => x.NumberParameterId,
                        principalTable: "NumberParameter",
                        principalColumn: "NumberParameterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceParameterCurrentValue_StringParameter_StringParameterId",
                        column: x => x.StringParameterId,
                        principalTable: "StringParameter",
                        principalColumn: "StringParameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameterCurrentValue_NumberParameterId",
                table: "DeviceParameterCurrentValue",
                column: "NumberParameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameterCurrentValue_StringParameterId",
                table: "DeviceParameterCurrentValue",
                column: "StringParameterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceParameterCurrentValue");
        }
    }
}
