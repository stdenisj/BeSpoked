using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSpoked.Db.Migrations
{
    /// <inheritdoc />
    public partial class Add_Sale_SalesPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "Sales");
        }
    }
}
