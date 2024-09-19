﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "aal_level", new[] { "aal1", "aal2", "aal3" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "code_challenge_method", new[] { "s256", "plain" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_status", new[] { "unverified", "verified" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_type", new[] { "totp", "webauthn", "phone" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pg_stat_statements");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgcrypto");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgjwt");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "uuid-ossp");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "graphql", "pg_graphql");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgsodium", "pgsodium");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "vault", "supabase_vault");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("seq_schema_version", "graphql")
                .IsCyclic();

            modelBuilder.Entity("Infrastructure.Models.ActivityRate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("Value")
                        .HasColumnType("double precision")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("Activity_Rates_pkey");

                    b.ToTable("Activity_Rates", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.FavoriteFood", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("jsonb")
                        .HasColumnName("address");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint")
                        .HasColumnName("food_id");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("text")
                        .HasColumnName("thumbnail");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("Favorite_Foods_pkey");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite_Foods", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double?>("Calories")
                        .HasColumnType("double precision")
                        .HasColumnName("calories");

                    b.Property<double?>("Carbohydrate")
                        .HasColumnType("double precision")
                        .HasColumnName("carbohydrate");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<double?>("Fat")
                        .HasColumnType("double precision")
                        .HasColumnName("fat");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("Protein")
                        .HasColumnType("double precision")
                        .HasColumnName("protein");

                    b.Property<string>("ServingUnit")
                        .HasColumnType("text")
                        .HasColumnName("serving_unit");

                    b.Property<double?>("ServingWeight")
                        .HasColumnType("double precision")
                        .HasColumnName("serving_weight");

                    b.HasKey("Id")
                        .HasName("Foods_pkey");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Infrastructure.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint")
                        .HasColumnName("food_id");

                    b.Property<long?>("RecipeId")
                        .HasColumnType("bigint")
                        .HasColumnName("recipe_id");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("Ingredients_pkey");

                    b.HasIndex("FoodId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Infrastructure.Models.MealSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("Meal_Schedules_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("Meal_Schedules", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Migration", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime?>("ExecutedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("executed_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("hash");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("migrations_pkey");

                    b.HasIndex(new[] { "Name" }, "migrations_name_key")
                        .IsUnique();

                    b.ToTable("migrations", "storage");
                });

            modelBuilder.Entity("Infrastructure.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<List<string>>("Images")
                        .HasColumnType("text[]")
                        .HasColumnName("images");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<long?>("ShopId")
                        .HasColumnType("bigint")
                        .HasColumnName("shop_id");

                    b.HasKey("Id")
                        .HasName("Products_pkey");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Infrastructure.Models.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<float?>("ReviewScore")
                        .HasColumnType("real")
                        .HasColumnName("review_score");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("TutorialUrl")
                        .HasColumnType("text")
                        .HasColumnName("tutorial_url");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("Recipes_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Infrastructure.Models.ScheduleItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long?>("RecipeId")
                        .HasColumnType("bigint")
                        .HasColumnName("recipe_id");

                    b.Property<long?>("ScheduleId")
                        .HasColumnType("bigint")
                        .HasColumnName("schedule_id");

                    b.HasKey("Id")
                        .HasName("Schedule_Items_pkey");

                    b.HasIndex("RecipeId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Schedule_Items", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Shop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("Shops_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Infrastructure.Models.Subscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Claims")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("claims");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("timezone('utc'::text, now())");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("subscription_id");

                    b.HasKey("Id")
                        .HasName("pk_subscription");

                    b.ToTable("subscription", "realtime");
                });

            modelBuilder.Entity("Infrastructure.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ActivityRateId")
                        .HasColumnType("bigint")
                        .HasColumnName("activity_rate_id");

                    b.Property<string>("Carts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("jsonb")
                        .HasColumnName("carts")
                        .HasDefaultValueSql("'[]'::jsonb");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<float?>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<float?>("Weight")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("Users_pkey");

                    b.HasIndex("ActivityRateId");

                    b.HasIndex(new[] { "Email" }, "Users_email_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "Users_phone_key")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.UsersRecipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("RecipeId")
                        .HasColumnType("bigint")
                        .HasColumnName("recipe_id");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("Users_Recipes_pkey");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Users_Recipes", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.FavoriteFood", b =>
                {
                    b.HasOne("Infrastructure.Models.Food", "Food")
                        .WithMany("FavoriteFoods")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("Favorite_Foods_food_id_fkey");

                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany("FavoriteFoods")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Favorite_Foods_user_id_fkey");

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.Ingredient", b =>
                {
                    b.HasOne("Infrastructure.Models.Food", "Food")
                        .WithMany("Ingredients")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("Ingredients_food_id_fkey");

                    b.HasOne("Infrastructure.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("Ingredients_recipe_id_fkey");

                    b.Navigation("Food");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Infrastructure.Models.MealSchedule", b =>
                {
                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany("MealSchedules")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Meal_Schedules_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.Product", b =>
                {
                    b.HasOne("Infrastructure.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .HasConstraintName("Products_shop_id_fkey");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Infrastructure.Models.Recipe", b =>
                {
                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Recipes_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.ScheduleItem", b =>
                {
                    b.HasOne("Infrastructure.Models.Recipe", "Recipe")
                        .WithMany("ScheduleItems")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("Schedule_Items_recipe_id_fkey");

                    b.HasOne("Infrastructure.Models.MealSchedule", "Schedule")
                        .WithMany("ScheduleItems")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("Schedule_Items_schedule_id_fkey");

                    b.Navigation("Recipe");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Infrastructure.Models.Shop", b =>
                {
                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany("Shops")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Shops_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.User", b =>
                {
                    b.HasOne("Infrastructure.Models.ActivityRate", "ActivityRate")
                        .WithMany("User1s")
                        .HasForeignKey("ActivityRateId")
                        .HasConstraintName("Users_activity_rate_id_fkey");

                    b.Navigation("ActivityRate");
                });

            modelBuilder.Entity("Infrastructure.Models.UsersRecipe", b =>
                {
                    b.HasOne("Infrastructure.Models.Recipe", "Recipe")
                        .WithMany("UsersRecipes")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("Users_Recipes_recipe_id_fkey");

                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany("UsersRecipes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Users_Recipes_user_id_fkey");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.ActivityRate", b =>
                {
                    b.Navigation("User1s");
                });

            modelBuilder.Entity("Infrastructure.Models.Food", b =>
                {
                    b.Navigation("FavoriteFoods");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Infrastructure.Models.MealSchedule", b =>
                {
                    b.Navigation("ScheduleItems");
                });

            modelBuilder.Entity("Infrastructure.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("ScheduleItems");

                    b.Navigation("UsersRecipes");
                });

            modelBuilder.Entity("Infrastructure.Models.Shop", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Infrastructure.Models.User", b =>
                {
                    b.Navigation("FavoriteFoods");

                    b.Navigation("MealSchedules");

                    b.Navigation("Recipes");

                    b.Navigation("Shops");

                    b.Navigation("UsersRecipes");
                });
#pragma warning restore 612, 618
        }
    }
}
