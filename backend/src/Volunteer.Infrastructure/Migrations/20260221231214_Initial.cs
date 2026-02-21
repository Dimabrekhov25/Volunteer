using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volunteer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    from_location_address_line = table.Column<string>(type: "text", nullable: true),
                    from_location_city = table.Column<string>(type: "text", nullable: true),
                    from_location_region = table.Column<string>(type: "text", nullable: true),
                    from_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    from_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    from_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    to_location_address_line = table.Column<string>(type: "text", nullable: true),
                    to_location_city = table.Column<string>(type: "text", nullable: true),
                    to_location_region = table.Column<string>(type: "text", nullable: true),
                    to_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    to_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    to_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    pickup_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    pickup_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    dropoff_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    dropoff_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    requirements = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    picked_up_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    delivered_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deliveries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    contact_name = table.Column<string>(type: "text", nullable: true),
                    contact_phone = table.Column<string>(type: "text", nullable: true),
                    contact_email = table.Column<string>(type: "text", nullable: true),
                    address_address_line = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    address_region = table.Column<string>(type: "text", nullable: true),
                    address_postal_code = table.Column<string>(type: "text", nullable: true),
                    address_latitude = table.Column<double>(type: "double precision", nullable: true),
                    address_longitude = table.Column<double>(type: "double precision", nullable: true),
                    manager_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    roles = table.Column<int[]>(type: "integer[]", nullable: false),
                    last_login_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_legs",
                columns: table => new
                {
                    index = table.Column<int>(type: "integer", nullable: false),
                    delivery_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_location_address_line = table.Column<string>(type: "text", nullable: true),
                    from_location_city = table.Column<string>(type: "text", nullable: true),
                    from_location_region = table.Column<string>(type: "text", nullable: true),
                    from_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    from_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    from_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    to_location_address_line = table.Column<string>(type: "text", nullable: true),
                    to_location_city = table.Column<string>(type: "text", nullable: true),
                    to_location_region = table.Column<string>(type: "text", nullable: true),
                    to_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    to_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    to_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    pickup_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    dropoff_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_delivery_legs", x => new { x.delivery_id, x.index });
                    table.ForeignKey(
                        name: "fk_delivery_legs_deliveries_delivery_id",
                        column: x => x.delivery_id,
                        principalTable: "deliveries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adopter_profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_address_line = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    address_region = table.Column<string>(type: "text", nullable: true),
                    address_postal_code = table.Column<string>(type: "text", nullable: true),
                    address_latitude = table.Column<double>(type: "double precision", nullable: true),
                    address_longitude = table.Column<double>(type: "double precision", nullable: true),
                    family_info = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    experience = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    availability = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adopter_profiles", x => x.id);
                    table.ForeignKey(
                        name: "fk_adopter_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "volunteer_profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    verification_status = table.Column<int>(type: "integer", nullable: false),
                    availability_status = table.Column<int>(type: "integer", nullable: false),
                    vehicle_type = table.Column<int>(type: "integer", nullable: true),
                    capacity = table.Column<int>(type: "integer", nullable: true),
                    species_allowed = table.Column<List<string>>(type: "text[]", nullable: false),
                    home_base_location_address_line = table.Column<string>(type: "text", nullable: true),
                    home_base_location_city = table.Column<string>(type: "text", nullable: true),
                    home_base_location_region = table.Column<string>(type: "text", nullable: true),
                    home_base_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    home_base_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    home_base_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    experience = table.Column<string>(type: "text", nullable: true),
                    emergency_contact_name = table.Column<string>(type: "text", nullable: true),
                    emergency_contact_phone = table.Column<string>(type: "text", nullable: true),
                    emergency_contact_email = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    completed_trips_count = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteer_profiles", x => x.id);
                    table.ForeignKey(
                        name: "fk_volunteer_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    species = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    adopter_profile_id = table.Column<Guid>(type: "uuid", nullable: true),
                    adopter_profile_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    sex = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    size = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    traits = table.Column<List<string>>(type: "text[]", nullable: false),
                    medical_status = table.Column<int>(type: "integer", nullable: false),
                    vaccinations = table.Column<List<string>>(type: "text[]", nullable: false),
                    sterilized = table.Column<bool>(type: "boolean", nullable: false),
                    microchip_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    current_location_address_line = table.Column<string>(type: "text", nullable: true),
                    current_location_city = table.Column<string>(type: "text", nullable: true),
                    current_location_region = table.Column<string>(type: "text", nullable: true),
                    current_location_postal_code = table.Column<string>(type: "text", nullable: true),
                    current_location_latitude = table.Column<double>(type: "double precision", nullable: true),
                    current_location_longitude = table.Column<double>(type: "double precision", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    owner_organization_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animals", x => x.id);
                    table.ForeignKey(
                        name: "fk_animals_adopter_profiles_adopter_profile_id",
                        column: x => x.adopter_profile_id,
                        principalTable: "adopter_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_animals_adopter_profiles_adopter_profile_id1",
                        column: x => x.adopter_profile_id1,
                        principalTable: "adopter_profiles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "animal_photos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animal_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_animal_photos_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "Animals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    issued_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    file_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_documents", x => x.id);
                    table.ForeignKey(
                        name: "fk_documents_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "Animals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_adopter_profiles_user_id",
                table: "adopter_profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_animal_photos_animal_id",
                table: "animal_photos",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_animals_adopter_profile_id",
                table: "Animals",
                column: "adopter_profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_animals_adopter_profile_id1",
                table: "Animals",
                column: "adopter_profile_id1");

            migrationBuilder.CreateIndex(
                name: "ix_documents_animal_id",
                table: "documents",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_volunteer_profiles_user_id",
                table: "volunteer_profiles",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animal_photos");

            migrationBuilder.DropTable(
                name: "delivery_legs");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "volunteer_profiles");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "adopter_profiles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
