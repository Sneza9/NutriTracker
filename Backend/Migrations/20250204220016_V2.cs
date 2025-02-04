﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "FK_IngredientNutritions_IngredientType_IngredientTypeId",
                table: "IngredientNutritions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientType",
                table: "IngredientType");

            migrationBuilder.RenameTable(
                name: "IngredientType",
                newName: "IngredientTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientTypes",
                table: "IngredientTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutritions_IngredientTypes_IngredientTypeId",
                table: "IngredientNutritions",
                column: "IngredientTypeId",
                principalTable: "IngredientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutritions_IngredientTypes_IngredientTypeId",
                table: "IngredientNutritions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientTypes",
                table: "IngredientTypes");

            migrationBuilder.RenameTable(
                name: "IngredientTypes",
                newName: "IngredientType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientType",
                table: "IngredientType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutritions_IngredientType_IngredientTypeId",
                table: "IngredientNutritions",
                column: "IngredientTypeId",
                principalTable: "IngredientType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
