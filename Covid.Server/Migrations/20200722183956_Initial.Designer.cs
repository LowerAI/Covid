// <auto-generated />
using System;
using Covid.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid.Server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200722183956_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Covid.Server.Entities.DailyHealth", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("HealthCondition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remark")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("EmployeeId", "Date");

                    b.ToTable("DailyHealths");
                });

            modelBuilder.Entity("Covid.Server.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "研发部"
                        },
                        new
                        {
                            Id = 2,
                            Name = "销售部"
                        },
                        new
                        {
                            Id = 3,
                            Name = "采购部"
                        });
                });

            modelBuilder.Entity("Covid.Server.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("No")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Gender = 2,
                            Name = "Nick Carter",
                            No = "A01",
                            PictureUrl = ""
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1975, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Gender = 2,
                            Name = "Mike Seaver",
                            No = "A02",
                            PictureUrl = ""
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1989, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Gender = 1,
                            Name = "Sarah Jackson",
                            No = "B01",
                            PictureUrl = ""
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1995, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Gender = 1,
                            Name = "Mary Bloody",
                            No = "B02",
                            PictureUrl = ""
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1979, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Gender = 2,
                            Name = "Joe Kent",
                            No = "C01",
                            PictureUrl = ""
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1961, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Gender = 2,
                            Name = "Axl",
                            No = "C02",
                            PictureUrl = ""
                        });
                });

            modelBuilder.Entity("Covid.Server.Entities.DailyHealth", b =>
                {
                    b.HasOne("Covid.Server.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Covid.Server.Entities.Employee", b =>
                {
                    b.HasOne("Covid.Server.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
