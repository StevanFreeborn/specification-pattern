﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Logic.Movies.Director", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Lana Wachowski"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Lilly Wachowski"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Roger Allers"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Rob Minkoff"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Robert Zemeckis"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "John Lasseter"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "David Fincher"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Francis Ford Coppola"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Frank Darabont"
                        });
                });

            modelBuilder.Entity("Logic.Movies.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MpaaRating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DirectorId = 1L,
                            Genre = "Sci-Fi",
                            MpaaRating = 3,
                            Name = "The Matrix",
                            Rating = 8.6999999999999993,
                            ReleaseDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            DirectorId = 2L,
                            Genre = "Sci-Fi",
                            MpaaRating = 2,
                            Name = "Inception",
                            Rating = 8.8000000000000007,
                            ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            DirectorId = 3L,
                            Genre = "Animation",
                            MpaaRating = 0,
                            Name = "The Lion King",
                            Rating = 8.5,
                            ReleaseDate = new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4L,
                            DirectorId = 7L,
                            Genre = "Crime",
                            MpaaRating = 3,
                            Name = "Pulp Fiction",
                            Rating = 8.9000000000000004,
                            ReleaseDate = new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5L,
                            DirectorId = 8L,
                            Genre = "Drama",
                            MpaaRating = 2,
                            Name = "Forrest Gump",
                            Rating = 8.8000000000000007,
                            ReleaseDate = new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6L,
                            DirectorId = 9L,
                            Genre = "Animation",
                            MpaaRating = 0,
                            Name = "Toy Story",
                            Rating = 8.3000000000000007,
                            ReleaseDate = new DateTime(1995, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7L,
                            DirectorId = 10L,
                            Genre = "Action",
                            MpaaRating = 2,
                            Name = "The Dark Knight",
                            Rating = 9.0,
                            ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8L,
                            DirectorId = 1L,
                            Genre = "Drama",
                            MpaaRating = 3,
                            Name = "Fight Club",
                            Rating = 8.8000000000000007,
                            ReleaseDate = new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9L,
                            DirectorId = 2L,
                            Genre = "Crime",
                            MpaaRating = 3,
                            Name = "The Godfather",
                            Rating = 9.1999999999999993,
                            ReleaseDate = new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10L,
                            DirectorId = 3L,
                            Genre = "Drama",
                            MpaaRating = 3,
                            Name = "The Shawshank Redemption",
                            Rating = 9.3000000000000007,
                            ReleaseDate = new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Logic.Movies.Movie", b =>
                {
                    b.HasOne("Logic.Movies.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("Logic.Movies.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
