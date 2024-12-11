using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelForRecipeFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Recipes");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Recipes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "durationInMinutes",
                table: "Recipes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instruction",
                table: "Recipes",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPublic",
                table: "Recipes",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "level",
                table: "Recipes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thumbnail",
                table: "Recipes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favorite_Recipes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_Recipes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Users_Recipes_recipe_id_fkey",
                        column: x => x.recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Users_Recipes_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Thumbnail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipesTags",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesTags", x => new { x.RecipeId, x.TagId });
                    table.ForeignKey(
                        name: "Recipes_Tags_recipe_id_fkey",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Recipes_Tags_tag_id_fkey",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_Recipes_recipe_id",
                table: "Favorite_Recipes",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_Recipes_user_id",
                table: "Favorite_Recipes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipesTags_TagId",
                table: "RecipesTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite_Recipes");

            migrationBuilder.DropTable(
                name: "RecipesTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "durationInMinutes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "instruction",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "isPublic",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "level",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "thumbnail",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "Users_Recipes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_Recipes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Users_Recipes_recipe_id_fkey",
                        column: x => x.recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Users_Recipes_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Recipes_recipe_id",
                table: "Users_Recipes",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Recipes_user_id",
                table: "Users_Recipes",
                column: "user_id");
        }
    }
}
