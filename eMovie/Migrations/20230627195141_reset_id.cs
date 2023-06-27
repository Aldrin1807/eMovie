using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMovie.Migrations
{
    /// <inheritdoc />
    public partial class reset_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DBCC CHECKIDENT ('Actors', RESEED, 1);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Movies', RESEED, 1);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Producers', RESEED, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
