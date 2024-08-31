using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Express_Spotilike.Migrations
{
    /// <inheritdoc />
    public partial class first_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArtisteItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_artiste = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    biographie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisteItems", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreItems", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlbumItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pochette = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_de_sortie = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    artiste_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlbumItems_ArtisteItems_artiste_id",
                        column: x => x.artiste_id,
                        principalTable: "ArtisteItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "morceaux",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    durée = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    artiste_id = table.Column<long>(type: "bigint", nullable: false),
                    genre_id = table.Column<long>(type: "bigint", nullable: false),
                    album_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_morceaux", x => x.id);
                    table.ForeignKey(
                        name: "FK_morceaux_AlbumItems_album_id",
                        column: x => x.album_id,
                        principalTable: "AlbumItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_morceaux_ArtisteItems_artiste_id",
                        column: x => x.artiste_id,
                        principalTable: "ArtisteItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_morceaux_GenreItems_genre_id",
                        column: x => x.genre_id,
                        principalTable: "GenreItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumItems_artiste_id",
                table: "AlbumItems",
                column: "artiste_id");

            migrationBuilder.CreateIndex(
                name: "IX_morceaux_album_id",
                table: "morceaux",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_morceaux_artiste_id",
                table: "morceaux",
                column: "artiste_id");

            migrationBuilder.CreateIndex(
                name: "IX_morceaux_genre_id",
                table: "morceaux",
                column: "genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "morceaux");

            migrationBuilder.DropTable(
                name: "AlbumItems");

            migrationBuilder.DropTable(
                name: "GenreItems");

            migrationBuilder.DropTable(
                name: "ArtisteItems");
        }
    }
}
