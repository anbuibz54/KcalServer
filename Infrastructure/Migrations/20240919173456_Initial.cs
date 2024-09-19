using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "storage");

            migrationBuilder.EnsureSchema(
                name: "realtime");

            migrationBuilder.EnsureSchema(
                name: "graphql");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:auth.aal_level", "aal1,aal2,aal3")
                .Annotation("Npgsql:Enum:auth.code_challenge_method", "s256,plain")
                .Annotation("Npgsql:Enum:auth.factor_status", "unverified,verified")
                .Annotation("Npgsql:Enum:auth.factor_type", "totp,webauthn,phone")
                .Annotation("Npgsql:Enum:auth.one_time_token_type", "confirmation_token,reauthentication_token,recovery_token,email_change_token_new,email_change_token_current,phone_change_token")
                .Annotation("Npgsql:Enum:pgsodium.key_status", "default,valid,invalid,expired")
                .Annotation("Npgsql:Enum:pgsodium.key_type", "aead-ietf,aead-det,hmacsha512,hmacsha256,auth,shorthash,generichash,kdf,secretbox,secretstream,stream_xchacha20")
                .Annotation("Npgsql:Enum:realtime.action", "INSERT,UPDATE,DELETE,TRUNCATE,ERROR")
                .Annotation("Npgsql:Enum:realtime.equality_op", "eq,neq,lt,lte,gt,gte,in")
                .Annotation("Npgsql:PostgresExtension:extensions.pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:extensions.pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:extensions.pgjwt", ",,")
                .Annotation("Npgsql:PostgresExtension:extensions.uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:graphql.pg_graphql", ",,")
                .Annotation("Npgsql:PostgresExtension:pgsodium.pgsodium", ",,")
                .Annotation("Npgsql:PostgresExtension:vault.supabase_vault", ",,");

            migrationBuilder.CreateSequence<int>(
                name: "seq_schema_version",
                schema: "graphql",
                cyclic: true);

            migrationBuilder.CreateTable(
                name: "Activity_Rates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Activity_Rates_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    calories = table.Column<double>(type: "double precision", nullable: true),
                    fat = table.Column<double>(type: "double precision", nullable: true),
                    protein = table.Column<double>(type: "double precision", nullable: true),
                    carbohydrate = table.Column<double>(type: "double precision", nullable: true),
                    serving_weight = table.Column<double>(type: "double precision", nullable: true),
                    serving_unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Foods_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "migrations",
                schema: "storage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    hash = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    executed_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("migrations_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                schema: "realtime",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    subscription_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claims = table.Column<string>(type: "jsonb", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "timezone('utc'::text, now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<float>(type: "real", nullable: true),
                    weight = table.Column<float>(type: "real", nullable: true),
                    activity_rate_id = table.Column<long>(type: "bigint", nullable: true),
                    carts = table.Column<string>(type: "jsonb", nullable: true, defaultValueSql: "'[]'::jsonb")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Users_activity_rate_id_fkey",
                        column: x => x.activity_rate_id,
                        principalTable: "Activity_Rates",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Favorite_Foods",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    food_id = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    thumbnail = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Favorite_Foods_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Favorite_Foods_food_id_fkey",
                        column: x => x.food_id,
                        principalTable: "Foods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Favorite_Foods_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Meal_Schedules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Meal_Schedules_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Meal_Schedules_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    tutorial_url = table.Column<string>(type: "text", nullable: true),
                    review_score = table.Column<float>(type: "real", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Recipes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Recipes_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Shops_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Shops_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    weight = table.Column<double>(type: "double precision", nullable: true),
                    food_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ingredients_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Ingredients_food_id_fkey",
                        column: x => x.food_id,
                        principalTable: "Foods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Ingredients_recipe_id_fkey",
                        column: x => x.recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule_Items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    schedule_id = table.Column<long>(type: "bigint", nullable: true),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Schedule_Items_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Schedule_Items_recipe_id_fkey",
                        column: x => x.recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Schedule_Items_schedule_id_fkey",
                        column: x => x.schedule_id,
                        principalTable: "Meal_Schedules",
                        principalColumn: "id");
                });

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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    images = table.Column<List<string>>(type: "text[]", nullable: true),
                    shop_id = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Products_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Products_shop_id_fkey",
                        column: x => x.shop_id,
                        principalTable: "Shops",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_Foods_food_id",
                table: "Favorite_Foods",
                column: "food_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_Foods_user_id",
                table: "Favorite_Foods",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_food_id",
                table: "Ingredients",
                column: "food_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_recipe_id",
                table: "Ingredients",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Schedules_user_id",
                table: "Meal_Schedules",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "migrations_name_key",
                schema: "storage",
                table: "migrations",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_shop_id",
                table: "Products",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_user_id",
                table: "Recipes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_Items_recipe_id",
                table: "Schedule_Items",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_Items_schedule_id",
                table: "Schedule_Items",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_user_id",
                table: "Shops",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_activity_rate_id",
                table: "Users",
                column: "activity_rate_id");

            migrationBuilder.CreateIndex(
                name: "Users_email_key",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users_phone_key",
                table: "Users",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Recipes_recipe_id",
                table: "Users_Recipes",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Recipes_user_id",
                table: "Users_Recipes",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite_Foods");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "migrations",
                schema: "storage");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Schedule_Items");

            migrationBuilder.DropTable(
                name: "subscription",
                schema: "realtime");

            migrationBuilder.DropTable(
                name: "Users_Recipes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Meal_Schedules");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Activity_Rates");

            migrationBuilder.DropSequence(
                name: "seq_schema_version",
                schema: "graphql");
        }
    }
}
