﻿// <auto-generated />
using System;
using Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogAPI.Migrations
{
    [DbContext(typeof(BlogDataContext))]
    partial class BlogDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Blog.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_Category_Slug")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2023, 12, 20, 17, 38, 35, 662, DateTimeKind.Utc).AddTicks(5590))
                        .HasColumnName("SMALLDATETIME");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Slug" }, "IX_Post_Slug")
                        .IsUnique();

                    b.ToTable("post", (string)null);
                });

            modelBuilder.Entity("Blog.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Blog.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_User_Slug")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.HasOne("Blog.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Post_Author");

                    b.HasOne("Blog.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Post_Category");

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("Blog.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_PostTag_PostId");

                    b.HasOne("Blog.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("Blog.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_PostTag_TagId");

                    b.HasOne("Blog.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_UserRole_UserId");
                });

            modelBuilder.Entity("Blog.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Blog.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
