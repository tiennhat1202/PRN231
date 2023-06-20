﻿// <auto-generated />
using System;
using BusinessObject.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObject.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email_address");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<double?>("Advance")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PubId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("published_date");

                    b.Property<double?>("Royalty")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("YtdSales")
                        .HasColumnType("float");

                    b.HasKey("BookId");

                    b.HasIndex("PubId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BusinessObject.Models.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorOrder")
                        .HasColumnType("int");

                    b.Property<double>("RoyaltyPercentage")
                        .HasColumnType("float");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BusinessObject.Models.Publisher", b =>
                {
                    b.Property<int>("PubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pub_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PubId"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("publisher_name");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PubId");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BusinessObject.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleDesc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_desc");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BusinessObject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email_address");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hire_date");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PubId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("PubId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.HasOne("BusinessObject.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BusinessObject.Models.BookAuthor", b =>
                {
                    b.HasOne("BusinessObject.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BusinessObject.Models.User", b =>
                {
                    b.HasOne("BusinessObject.Models.Publisher", "Publisher")
                        .WithMany("Users")
                        .HasForeignKey("PubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BusinessObject.Models.Publisher", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObject.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}