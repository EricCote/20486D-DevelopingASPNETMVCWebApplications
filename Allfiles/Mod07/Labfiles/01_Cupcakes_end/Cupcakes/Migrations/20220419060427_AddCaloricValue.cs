﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cupcakes.Migrations
{
    public partial class AddCaloricValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloricValue",
                table: "Cupcakes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cupcakes",
                keyColumn: "CupcakeId",
                keyValue: 1,
                column: "CaloricValue",
                value: 355);

            migrationBuilder.UpdateData(
                table: "Cupcakes",
                keyColumn: "CupcakeId",
                keyValue: 2,
                column: "CaloricValue",
                value: 195);

            migrationBuilder.UpdateData(
                table: "Cupcakes",
                keyColumn: "CupcakeId",
                keyValue: 3,
                column: "CaloricValue",
                value: 295);

            migrationBuilder.UpdateData(
                table: "Cupcakes",
                keyColumn: "CupcakeId",
                keyValue: 4,
                column: "CaloricValue",
                value: 360);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloricValue",
                table: "Cupcakes");
        }
    }
}
