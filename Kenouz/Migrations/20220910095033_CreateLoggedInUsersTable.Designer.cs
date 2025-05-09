﻿// <auto-generated />
using Kenouz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kenouz.Migrations
{
    [DbContext(typeof(Logged_in_Users_DbContext))]
    [Migration("20220910095033_CreateLoggedInUsersTable")]
    partial class CreateLoggedInUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kenouz.Data.Logged_in_Users", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("UserID");

                    b.ToTable("Logged_In_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
