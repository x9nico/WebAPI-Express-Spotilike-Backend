﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Express_Spotilike.Models;

#nullable disable

namespace WebAPI_Express_Spotilike.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20240831212609_first_tables")]
    partial class first_tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.AlbumItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("ArtisteId")
                        .HasColumnType("bigint")
                        .HasColumnName("artiste_id");

                    b.Property<DateTime>("date_de_sortie")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("pochette")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("ArtisteId");

                    b.ToTable("AlbumItems");
                });

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.ArtisteItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("avatar_url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("biographie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nom_artiste")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("ArtisteItems");
                });

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.GenreItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("GenreItems");
                });

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.MorceauItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint")
                        .HasColumnName("album_id");

                    b.Property<long>("ArtisteId")
                        .HasColumnType("bigint")
                        .HasColumnName("artiste_id");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint")
                        .HasColumnName("genre_id");

                    b.Property<TimeSpan>("durée")
                        .HasColumnType("time(6)");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtisteId");

                    b.HasIndex("GenreId");

                    b.ToTable("morceaux");
                });

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.AlbumItem", b =>
                {
                    b.HasOne("WebAPI_Express_Spotilike.Models.ArtisteItem", "Artiste")
                        .WithMany()
                        .HasForeignKey("ArtisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiste");
                });

            modelBuilder.Entity("WebAPI_Express_Spotilike.Models.MorceauItem", b =>
                {
                    b.HasOne("WebAPI_Express_Spotilike.Models.AlbumItem", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI_Express_Spotilike.Models.ArtisteItem", "Artiste")
                        .WithMany()
                        .HasForeignKey("ArtisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI_Express_Spotilike.Models.GenreItem", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artiste");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
