using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Recipes_RecipeId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Users_UserId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationWorkoutLog_Medications_UserId",
                table: "MedicationWorkoutLog");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationWorkoutLog_Users_UserId",
                table: "MedicationWorkoutLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationWorkoutLog",
                table: "MedicationWorkoutLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MedicationTime",
                table: "MedicationWorkoutLog");

            migrationBuilder.RenameTable(
                name: "MedicationWorkoutLog",
                newName: "MedicationWorkoutLogs");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameColumn(
                name: "MedicationTimeId",
                table: "MedicationWorkoutLogs",
                newName: "MedicationId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationWorkoutLog_UserId",
                table: "MedicationWorkoutLogs",
                newName: "IX_MedicationWorkoutLogs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_UserId",
                table: "Meals",
                newName: "IX_Meals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_RecipeId",
                table: "Meals",
                newName: "IX_Meals_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "MedicationWorkoutLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationWorkoutLogs",
                table: "MedicationWorkoutLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationWorkoutLogs_MedicationId",
                table: "MedicationWorkoutLogs",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Recipes_RecipeId",
                table: "Meals",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationWorkoutLogs_Medications_MedicationId",
                table: "MedicationWorkoutLogs",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationWorkoutLogs_Users_UserId",
                table: "MedicationWorkoutLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Recipes_RecipeId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationWorkoutLogs_Medications_MedicationId",
                table: "MedicationWorkoutLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationWorkoutLogs_Users_UserId",
                table: "MedicationWorkoutLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationWorkoutLogs",
                table: "MedicationWorkoutLogs");

            migrationBuilder.DropIndex(
                name: "IX_MedicationWorkoutLogs_MedicationId",
                table: "MedicationWorkoutLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "MedicationWorkoutLogs");

            migrationBuilder.RenameTable(
                name: "MedicationWorkoutLogs",
                newName: "MedicationWorkoutLog");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameColumn(
                name: "MedicationId",
                table: "MedicationWorkoutLog",
                newName: "MedicationTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationWorkoutLogs_UserId",
                table: "MedicationWorkoutLog",
                newName: "IX_MedicationWorkoutLog_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserId",
                table: "Meal",
                newName: "IX_Meal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_RecipeId",
                table: "Meal",
                newName: "IX_Meal_RecipeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "MedicationTime",
                table: "MedicationWorkoutLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationWorkoutLog",
                table: "MedicationWorkoutLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Recipes_RecipeId",
                table: "Meal",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Users_UserId",
                table: "Meal",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationWorkoutLog_Medications_UserId",
                table: "MedicationWorkoutLog",
                column: "UserId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationWorkoutLog_Users_UserId",
                table: "MedicationWorkoutLog",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
