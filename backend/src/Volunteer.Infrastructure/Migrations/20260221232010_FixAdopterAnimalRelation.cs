using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volunteer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAdopterAnimalRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_animals_adopter_profiles_adopter_profile_id1",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "ix_animals_adopter_profile_id1",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "adopter_profile_id1",
                table: "Animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "adopter_profile_id1",
                table: "Animals",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_animals_adopter_profile_id1",
                table: "Animals",
                column: "adopter_profile_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_animals_adopter_profiles_adopter_profile_id1",
                table: "Animals",
                column: "adopter_profile_id1",
                principalTable: "adopter_profiles",
                principalColumn: "id");
        }
    }
}
