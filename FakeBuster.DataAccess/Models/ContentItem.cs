using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class ContentItem
{
    public int Id { get; set; }

    public string? Language { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<TvShow> TvShows { get; set; } = new List<TvShow>();
}
