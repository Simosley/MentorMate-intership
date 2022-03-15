﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODOApi.Data;

#nullable disable

namespace TODOApi.Data.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20220222182055_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TODOApi.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("StatusEnum")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TodoItemPriorityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoItemPriorityId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TODOApi.Models.TodoItemPriority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityId");

                    b.ToTable("TodoItemsPriority");

                    b.HasData(
                        new
                        {
                            PriorityId = 1,
                            Title = "Low"
                        },
                        new
                        {
                            PriorityId = 2,
                            Title = "Medium"
                        },
                        new
                        {
                            PriorityId = 3,
                            Title = "High"
                        });
                });

            modelBuilder.Entity("TODOApi.Models.TodoItem", b =>
                {
                    b.HasOne("TODOApi.Models.TodoItemPriority", "TodoItemPriority")
                        .WithMany()
                        .HasForeignKey("TodoItemPriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoItemPriority");
                });
#pragma warning restore 612, 618
        }
    }
}