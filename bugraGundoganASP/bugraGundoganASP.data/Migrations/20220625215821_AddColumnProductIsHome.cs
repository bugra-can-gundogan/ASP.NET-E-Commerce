﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bugraGundoganASP.data.Migrations
{
    public partial class AddColumnProductIsHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Products");
        }
    }
}
