using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class CoreContext : DbContext
{
    public CoreContext()
    {
    }

    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityRate> ActivityRates { get; set; }


    public virtual DbSet<FavoriteFood> FavoriteFoods { get; set; }


    public virtual DbSet<Food> Foods { get; set; }


    public virtual DbSet<Ingredient> Ingredients { get; set; }


    public virtual DbSet<MealSchedule> MealSchedules { get; set; }




    public virtual DbSet<Migration> Migrations { get; set; }



    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }


    public virtual DbSet<ScheduleItem> ScheduleItems { get; set; }


    public virtual DbSet<Shop> Shops { get; set; }


    public virtual DbSet<Subscription> Subscriptions { get; set; }



    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<FavoriteRecipes> UsersRecipes { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<RecipesTags> RecipesTags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Kcal");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
            .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "pgjwt")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("pgsodium", "pgsodium")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<ActivityRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Activity_Rates_pkey");

            entity.ToTable("Activity_Rates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });



        modelBuilder.Entity<FavoriteFood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Favorite_Foods_pkey");

            entity.ToTable("Favorite_Foods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("jsonb")
                .HasColumnName("address");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.Thumbnail).HasColumnName("thumbnail");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Food).WithMany(p => p.FavoriteFoods)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("Favorite_Foods_food_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteFoods)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Favorite_Foods_user_id_fkey");
        });


        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Foods_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Carbohydrate).HasColumnName("carbohydrate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Fat).HasColumnName("fat");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Protein).HasColumnName("protein");
            entity.Property(e => e.ServingUnit).HasColumnName("serving_unit");
            entity.Property(e => e.ServingWeight).HasColumnName("serving_weight");
        });


        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Ingredients_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Food).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("Ingredients_food_id_fkey");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("Ingredients_recipe_id_fkey");
        });


        modelBuilder.Entity<MealSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Meal_Schedules_pkey");

            entity.ToTable("Meal_Schedules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.MealSchedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Meal_Schedules_user_id_fkey");
        });


        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("migrations_pkey");

            entity.ToTable("migrations", "storage");

            entity.HasIndex(e => e.Name, "migrations_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ExecutedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("executed_at");
            entity.Property(e => e.Hash)
                .HasMaxLength(40)
                .HasColumnName("hash");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShopId).HasColumnName("shop_id");

            entity.HasOne(d => d.Shop).WithMany(p => p.Products)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("Products_shop_id_fkey");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Recipes_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ReviewScore).HasColumnName("review_score");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.TutorialUrl).HasColumnName("tutorial_url");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Thumbnail).HasColumnName("thumbnail");
            entity.Property(e => e.DurationInMinutes).HasColumnName("durationInMinutes");
            entity.Property(e => e.IsPublic).HasColumnName("isPublic");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Instruction).HasColumnName("instruction");
            entity.Property(e => e.Instruction).HasColumnType("json");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Recipes_user_id_fkey");
        });

        modelBuilder.Entity<ScheduleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Schedule_Items_pkey");

            entity.ToTable("Schedule_Items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.ScheduleItems)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("Schedule_Items_recipe_id_fkey");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleItems)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("Schedule_Items_schedule_id_fkey");
        });


        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Shops_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Shops)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Shops_user_id_fkey");
        });


        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_subscription");

            entity.ToTable("subscription", "realtime");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Claims)
                .HasColumnType("jsonb")
                .HasColumnName("claims");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");
 
            entity.ToTable("Users");

            entity.HasIndex(e => e.Email, "Users_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "Users_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityRateId).HasColumnName("activity_rate_id");
            entity.Property(e => e.Carts)
                .HasDefaultValueSql("'[]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("carts");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.ActivityRate).WithMany(p => p.User1s)
                .HasForeignKey(d => d.ActivityRateId)
                .HasConstraintName("Users_activity_rate_id_fkey");
        });

        modelBuilder.Entity<FavoriteRecipes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_Recipes_pkey");

            entity.ToTable("FavoriteRecipes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("Users_Recipes_recipe_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Users_Recipes_user_id_fkey");
        });
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tags");
        });
        modelBuilder.Entity<RecipesTags>(entity =>
        {
            entity.HasKey(c => new { c.RecipeId, c.TagId });
            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipesTags)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("Recipes_Tags_recipe_id_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.RecipesTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("Recipes_Tags_tag_id_fkey");
        });
        modelBuilder.HasSequence<int>("seq_schema_version", "graphql").IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
