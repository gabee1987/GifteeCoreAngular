﻿// <auto-generated />
using System;
using GifteeCoreAngular.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace GifteeCoreAngular.Migrations
{
    [DbContext(typeof(GifteeDbContext))]
    [Migration("20180315133618_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.EventGift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int>("GiftId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GiftId");

                    b.ToTable("EventsGifts");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("StoreLink");

                    b.HasKey("Id");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Giftee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(64);

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.Property<string>("NickName")
                        .HasMaxLength(255);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Giftees");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.GifteeEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int>("GifteeId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GifteeId");

                    b.ToTable("GifteesEvents");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GiftId");

                    b.Property<int>("GifteeId");

                    b.HasKey("Id");

                    b.HasIndex("GiftId");

                    b.HasIndex("GifteeId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.EventGift", b =>
                {
                    b.HasOne("GifteeCoreAngular.Core.Models.Event", "Event")
                        .WithMany("EventGifts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GifteeCoreAngular.Core.Models.Gift", "Gift")
                        .WithMany("EventGifts")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Giftee", b =>
                {
                    b.HasOne("GifteeCoreAngular.Core.Models.User", "User")
                        .WithMany("Giftees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.GifteeEvent", b =>
                {
                    b.HasOne("GifteeCoreAngular.Core.Models.Event", "Event")
                        .WithMany("GifteeEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GifteeCoreAngular.Core.Models.Giftee", "Giftee")
                        .WithMany("GifteeEvents")
                        .HasForeignKey("GifteeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GifteeCoreAngular.Core.Models.Wishlist", b =>
                {
                    b.HasOne("GifteeCoreAngular.Core.Models.Gift", "Gift")
                        .WithMany("Wishlist")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GifteeCoreAngular.Core.Models.Giftee", "Giftee")
                        .WithMany("Wishlist")
                        .HasForeignKey("GifteeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
