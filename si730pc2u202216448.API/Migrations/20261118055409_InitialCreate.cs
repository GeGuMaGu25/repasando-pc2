using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace si730pc2u202216448.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "heroes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    hero_id = table.Column<long>(type: "bigint", nullable: false),
                    register_email_address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    hero_place = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    hero_country = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    hero_continent = table.Column<int>(type: "int", nullable: false),
                    hero_ability = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    register_date_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_heroes", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_heroes_hero_id_hero_place_hero_country_hero_continent",
                table: "heroes",
                columns: new[] { "hero_id", "hero_place", "hero_country", "hero_continent" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heroes");
        }
    }
}
