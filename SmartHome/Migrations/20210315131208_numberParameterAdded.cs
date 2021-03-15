using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class numberParameterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberParameter",
                columns: table => new
                {
                    NumberParameterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MaxValue = table.Column<long>(type: "bigint", nullable: false),
                    MinValue = table.Column<long>(type: "bigint", nullable: false),
                    DefaultValue = table.Column<long>(type: "bigint", nullable: false),
                    NumberParameterId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberParameter", x => x.NumberParameterId);
                    table.ForeignKey(
                        name: "FK_NumberParameter_NumberParameter_NumberParameterId1",
                        column: x => x.NumberParameterId1,
                        principalTable: "NumberParameter",
                        principalColumn: "NumberParameterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumberParameter_NumberParameterId1",
                table: "NumberParameter",
                column: "NumberParameterId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberParameter");
        }
    }
}
