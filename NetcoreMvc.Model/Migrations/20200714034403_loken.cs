using Microsoft.EntityFrameworkCore.Migrations;

namespace NetcoreMvc.Model.Migrations
{
    public partial class loken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsinStock",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsinStock",
                table: "Users");
        }
    }
}
