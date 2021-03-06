﻿// <auto-generated />
using System;
using BeltExam2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeltExam2.Migrations
{
    [DbContext(typeof(BeltContext))]
    [Migration("20190823191229_AddKeyToAssociated")]
    partial class AddKeyToAssociated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeltExam2.Models.AssociatedActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("DojoActivityId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("DojoActivityId");

                    b.HasIndex("UserID");

                    b.ToTable("AssociatedActivities");
                });

            modelBuilder.Entity("BeltExam2.Models.DojoActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("Duration");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("PlannedDate");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DojoActivitiesDb");
                });

            modelBuilder.Entity("BeltExam2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam2.Models.AssociatedActivity", b =>
                {
                    b.HasOne("BeltExam2.Models.DojoActivity", "JoinedActivity")
                        .WithMany("Attendees")
                        .HasForeignKey("DojoActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeltExam2.Models.User", "JoinedUser")
                        .WithMany("JoinedActivties")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeltExam2.Models.DojoActivity", b =>
                {
                    b.HasOne("BeltExam2.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
