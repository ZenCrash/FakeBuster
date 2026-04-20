/* CREATE Fake_Buster DATABASE */
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Fake_Buster')
    BEGIN
        CREATE DATABASE [Fake_Buster];
    END;
GO

USE [Fake_Buster];
GO

CREATE TABLE [Addresses](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [city] NVARCHAR(255) NULL,
    [zip_code] NVARCHAR(255) NULL,
    [country] NVARCHAR(255) NULL
);
GO

CREATE TABLE [Persons](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [name] NVARCHAR(255) NULL,
    [age] INT NULL,
    [email] NVARCHAR(255) NULL,
    [mobile_number] NVARCHAR(255) NULL,
    [address_id] INT NOT NULL,
    [deactivated_user] BIT DEFAULT 0,

    CONSTRAINT [FK_persons_addresses] FOREIGN KEY (address_id) REFERENCES Addresses(id)
);
GO

CREATE TABLE [Bookings](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [person_id] INT NOT NULL,

    CONSTRAINT [FK_bookings_persons] FOREIGN KEY (person_id) REFERENCES Persons(id) ON DELETE CASCADE
);
GO

CREATE TABLE [Movies](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [title] NVARCHAR(255) NOT NULL,
    [description] NVARCHAR(1023) NULL,
    [release_date] DATE NULL,
    [duration_minutes] INT NULL,
);
GO

CREATE TABLE [Tv_Shows](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [episode_count] INT NOT NULL,
    [season_number] INT NOT NULL,
    [title] NVARCHAR(255) NOT NULL,
    [description] NVARCHAR(1023) NULL,
    [release_date] DATE NULL,
    [duration_minutes] INT NULL,
);
GO

CREATE TABLE [Content_Items](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [language] NVARCHAR(255) NULL,
    [movie_id] INT NULL,
    [tv_show_id] INT NULL,
    [booking_id] INT NULL,

    CONSTRAINT [FK_content_items_tv_shows] FOREIGN KEY (movie_id) REFERENCES Movies(id) ON DELETE CASCADE,
    CONSTRAINT [FK_content_items_movies] FOREIGN KEY (tv_show_id) REFERENCES Tv_Shows(id) ON DELETE CASCADE,
    CONSTRAINT [FK_content_items_bookings] FOREIGN KEY (booking_id) REFERENCES Bookings(id)
);
GO

CREATE TABLE [Genres](
    [id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [name] NVARCHAR(255) NOT NULL
);
GO

/* Bridge Tables */

CREATE TABLE [Genres_Movies](
    [genre_id] INT NOT NULL,
    [movie_id] INT NOT NULL,

    CONSTRAINT [PK_genres_movies] PRIMARY KEY (genre_id, movie_id),
    CONSTRAINT [FK_genres_movies_genres] FOREIGN KEY (genre_id) REFERENCES Genres(id) ON DELETE CASCADE,
    CONSTRAINT [FK_genres_movies_movies] FOREIGN KEY (movie_id) REFERENCES Movies(id) ON DELETE CASCADE
);
GO

CREATE TABLE [Genres_Tv_Shows](
    [genre_id] INT NOT NULL,
    [tv_show_id] INT NOT NULL,

    CONSTRAINT [PK_genres_tv_shows] PRIMARY KEY (genre_id, tv_show_id),
    CONSTRAINT [FK_genres_tv_shows_genres] FOREIGN KEY (genre_id) REFERENCES Genres(id) ON DELETE CASCADE,
    CONSTRAINT [FK_genres_tv_shows_tv_shows] FOREIGN KEY (tv_show_id) REFERENCES Tv_Shows(id) ON DELETE CASCADE
);
GO