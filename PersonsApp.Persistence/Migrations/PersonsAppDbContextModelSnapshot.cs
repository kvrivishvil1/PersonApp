﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonsApp.Persistence;

namespace PersonsApp.Persistence.Migrations
{
    [DbContext(typeof(PersonsAppDbContext))]
    partial class PersonsAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonsApp.Domain.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "თბილისი"
                        },
                        new
                        {
                            ID = 2,
                            Name = "ბათუმი"
                        },
                        new
                        {
                            ID = 3,
                            Name = "ქუთაისი"
                        });
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "ქალი"
                        },
                        new
                        {
                            ID = 2,
                            Name = "კაცი"
                        });
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalN")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PersonConnection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConnectedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConnectedPersonId");

                    b.HasIndex("ConnectionTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonConnections");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PersonConnectionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("PersonConnectionTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "კოლეგა"
                        },
                        new
                        {
                            ID = 2,
                            Name = "ნაცნობი"
                        },
                        new
                        {
                            ID = 3,
                            Name = "ნათესავი"
                        },
                        new
                        {
                            ID = 4,
                            Name = "სხვა"
                        });
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneTypeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhoneTypeId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PhoneType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("PhoneType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "მობილური"
                        },
                        new
                        {
                            ID = 2,
                            Name = "ოფისის"
                        },
                        new
                        {
                            ID = 3,
                            Name = "სახლის"
                        });
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.Person", b =>
                {
                    b.HasOne("PersonsApp.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonsApp.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PersonConnection", b =>
                {
                    b.HasOne("PersonsApp.Domain.Entities.Person", "ConnectedPerson")
                        .WithMany()
                        .HasForeignKey("ConnectedPersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PersonsApp.Domain.Entities.PersonConnectionType", "ConnectionType")
                        .WithMany()
                        .HasForeignKey("ConnectionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonsApp.Domain.Entities.Person", "Person")
                        .WithMany("ConnectedPerson")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConnectedPerson");

                    b.Navigation("ConnectionType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("PersonsApp.Domain.Entities.Person", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonsApp.Domain.Entities.PhoneType", "PhoneType")
                        .WithMany()
                        .HasForeignKey("PhoneTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhoneType");
                });

            modelBuilder.Entity("PersonsApp.Domain.Entities.Person", b =>
                {
                    b.Navigation("ConnectedPerson");

                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
