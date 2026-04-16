using System;
using System.Collections.Generic;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Data;

public partial class FakeBusterContext : DbContext
{
    public FakeBusterContext()
    {
    }

    public FakeBusterContext(DbContextOptions<FakeBusterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<ContentItem> ContentItems { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<TvShow> TvShows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3213E83FD27DA294");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(255)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3213E83FA55064F0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_bookings_persons");
        });

        modelBuilder.Entity<ContentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Content___3213E83FE1CDC668");

            entity.ToTable("Content_Items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");

            entity.HasOne(d => d.Booking).WithMany(p => p.ContentItems)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_content_items_bookings");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3213E83FEDFC6100");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.Movies).WithMany(p => p.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "GenresMovie",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_genres_movies_movies"),
                    l => l.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_genres_movies_genres"),
                    j =>
                    {
                        j.HasKey("GenreId", "MovieId").HasName("PK_genres_movies");
                        j.ToTable("Genres_Movies");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                    });

            entity.HasMany(d => d.TvShows).WithMany(p => p.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "GenresTvShow",
                    r => r.HasOne<TvShow>().WithMany()
                        .HasForeignKey("TvShowId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_genres_tv_shows_tv_shows"),
                    l => l.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_genres_tv_shows_genres"),
                    j =>
                    {
                        j.HasKey("GenreId", "TvShowId").HasName("PK_genres_tv_shows");
                        j.ToTable("Genres_Tv_Shows");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                        j.IndexerProperty<int>("TvShowId").HasColumnName("tv_show_id");
                    });
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3213E83F84214980");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentItemId).HasColumnName("content_item_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1023)
                .HasColumnName("description");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.ContentItem).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ContentItemId)
                .HasConstraintName("FK_movies_content_items");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3213E83F473E0BAC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DeactivatedUser)
                .HasDefaultValue(false)
                .HasColumnName("deactivated_user");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(255)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_persons_addresses");
        });

        modelBuilder.Entity<TvShow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tv_Shows__3213E83F770BB258");

            entity.ToTable("Tv_Shows");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentItemId).HasColumnName("content_item_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1023)
                .HasColumnName("description");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.EpisodeCount).HasColumnName("episode_count");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.SeasonNumber).HasColumnName("season_number");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.ContentItem).WithMany(p => p.TvShows)
                .HasForeignKey(d => d.ContentItemId)
                .HasConstraintName("FK_tv_shows_content_items");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
