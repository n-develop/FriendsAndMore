﻿// <auto-generated />
using System;
using FriendsAndMore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FriendsAndMore.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201120233848_AddedStatusUpdates")]
    partial class AddedStatusUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Employer")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            FirstName = "Max",
                            LastName = "Mustermann"
                        },
                        new
                        {
                            ContactId = 2,
                            FirstName = "Manuela",
                            LastName = "Mustermann"
                        },
                        new
                        {
                            ContactId = 3,
                            FirstName = "John",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.EmailAddress", b =>
                {
                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmailAddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("EmailAddresses");

                    b.HasData(
                        new
                        {
                            EmailAddressId = 1,
                            ContactId = 1,
                            Email = "max@mustermann.de",
                            Type = "private"
                        },
                        new
                        {
                            EmailAddressId = 2,
                            ContactId = 2,
                            Email = "manuela@mustermann.de",
                            Type = "private"
                        },
                        new
                        {
                            EmailAddressId = 3,
                            ContactId = 3,
                            Email = "john.smith@ee-mail.de",
                            Type = "private"
                        },
                        new
                        {
                            EmailAddressId = 4,
                            ContactId = 1,
                            Email = "max@enterprise-stuff.de",
                            Type = "work"
                        });
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.Relationship", b =>
                {
                    b.Property<int>("RelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RelationshipId");

                    b.HasIndex("ContactId");

                    b.ToTable("Relationships");

                    b.HasData(
                        new
                        {
                            RelationshipId = 1,
                            ContactId = 1,
                            Person = "Manuela Mustermann",
                            Type = "Wife"
                        },
                        new
                        {
                            RelationshipId = 2,
                            ContactId = 2,
                            Person = "Max Mustermann",
                            Type = "Husband"
                        });
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.StatusUpdate", b =>
                {
                    b.Property<int>("StatusUpdateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusUpdateId");

                    b.HasIndex("ContactId");

                    b.ToTable("StatusUpdates");

                    b.HasData(
                        new
                        {
                            StatusUpdateId = 1,
                            ContactId = 3,
                            Created = new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusText = "He quit his job."
                        });
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.EmailAddress", b =>
                {
                    b.HasOne("FriendsAndMore.DataAccess.Entities.Contact", "Contact")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.Relationship", b =>
                {
                    b.HasOne("FriendsAndMore.DataAccess.Entities.Contact", "Contact")
                        .WithMany("Relationships")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.StatusUpdate", b =>
                {
                    b.HasOne("FriendsAndMore.DataAccess.Entities.Contact", "Contact")
                        .WithMany("StatusUpdates")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("FriendsAndMore.DataAccess.Entities.Contact", b =>
                {
                    b.Navigation("EmailAddresses");

                    b.Navigation("Relationships");

                    b.Navigation("StatusUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
