﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.ApplicationDbContext;

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Entity.Book", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("BookName");

                    b.Property<string>("Category");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifyBy");

                    b.Property<DateTime?>("LastModifyTime");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Repository.Entity.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifyBy");

                    b.Property<DateTime?>("LastModifyTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("UserEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
