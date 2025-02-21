using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRecipes_Recipes_RecipeId1",
                table: "FavoriteRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRecipes_Users_UserId1",
                table: "FavoriteRecipes");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteRecipes_RecipeId1",
                table: "FavoriteRecipes");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteRecipes_UserId1",
                table: "FavoriteRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "FavoriteRecipes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FavoriteRecipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "FavoriteRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "FavoriteRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRecipes_RecipeId1",
                table: "FavoriteRecipes",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRecipes_UserId1",
                table: "FavoriteRecipes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRecipes_Recipes_RecipeId1",
                table: "FavoriteRecipes",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRecipes_Users_UserId1",
                table: "FavoriteRecipes",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
