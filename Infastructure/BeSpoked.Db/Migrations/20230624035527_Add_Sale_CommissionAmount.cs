using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSpoked.Db.Migrations
{
    /// <inheritdoc />
    public partial class Add_Sale_CommissionAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CommissionAmount",
                table: "Sales",
                type: "TEXT",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionAmount",
                table: "Sales");
        }
    }
}
