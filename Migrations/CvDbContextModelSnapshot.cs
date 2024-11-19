﻿// <auto-generated />
using System;
using CV_creator.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CV_creator.Migrations
{
    [DbContext(typeof(CvDbContext))]
    partial class CvDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CV_creator.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BasicInformationId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("EducationId")
                        .HasColumnType("int");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BasicInformationId")
                        .IsUnique()
                        .HasFilter("[BasicInformationId] IS NOT NULL");

                    b.HasIndex("EducationId")
                        .IsUnique()
                        .HasFilter("[EducationId] IS NOT NULL");

                    b.HasIndex("JobId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CV_creator.Models.BasicInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("BasicInformations");
                });

            modelBuilder.Entity("CV_creator.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasicInformationId")
                        .HasColumnType("int");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BasicInformationId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("CV_creator.Models.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CV_creator.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasicInformationId")
                        .HasColumnType("int");

                    b.Property<string>("EmploymentType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PositionHeld")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BasicInformationId");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("CV_creator.Models.Address", b =>
                {
                    b.HasOne("CV_creator.Models.BasicInformation", "BasicInformation")
                        .WithOne("ResidenceAddress")
                        .HasForeignKey("CV_creator.Models.Address", "BasicInformationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CV_creator.Models.Education", "Education")
                        .WithOne("InstitutionAddress")
                        .HasForeignKey("CV_creator.Models.Address", "EducationId");

                    b.HasOne("CV_creator.Models.WorkExperience", "Job")
                        .WithMany("WorkAddresses")
                        .HasForeignKey("JobId");

                    b.Navigation("BasicInformation");

                    b.Navigation("Education");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("CV_creator.Models.Education", b =>
                {
                    b.HasOne("CV_creator.Models.BasicInformation", "BasicInformation")
                        .WithMany("Educations")
                        .HasForeignKey("BasicInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicInformation");
                });

            modelBuilder.Entity("CV_creator.Models.Skills", b =>
                {
                    b.HasOne("CV_creator.Models.WorkExperience", "Job")
                        .WithMany("Skills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("CV_creator.Models.WorkExperience", b =>
                {
                    b.HasOne("CV_creator.Models.BasicInformation", "BasicInformation")
                        .WithMany("Jobs")
                        .HasForeignKey("BasicInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicInformation");
                });

            modelBuilder.Entity("CV_creator.Models.BasicInformation", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Jobs");

                    b.Navigation("ResidenceAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("CV_creator.Models.Education", b =>
                {
                    b.Navigation("InstitutionAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("CV_creator.Models.WorkExperience", b =>
                {
                    b.Navigation("Skills");

                    b.Navigation("WorkAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
