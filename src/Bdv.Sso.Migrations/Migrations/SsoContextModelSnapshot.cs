﻿// <auto-generated />
using System;
using Bdv.Sso.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bdv.Sso.Migrations.Migrations
{
    [DbContext(typeof(SsoContext))]
    partial class SsoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bdv.Sso.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool?>("IsEmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("is_email_confirmed");

                    b.Property<bool?>("IsNeedChangePassword")
                        .HasColumnType("boolean")
                        .HasColumnName("is_need_change_password");

                    b.Property<bool?>("IsPhoneConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("is_phone_confirmed");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55197c22-0d7c-48f6-90c3-6870f761f87c"),
                            IsNeedChangePassword = true,
                            Login = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}