using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stdDetails.Migrations
{
    /// <inheritdoc />
    public partial class stdDetailsAddStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentStandard",
                table: "SecondStudents",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentStandard",
                table: "SecondStudents");
        }
    }
}
