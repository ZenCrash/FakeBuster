using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class ContentItem
{
    public int Id { get; set; }

    public string? Language { get; set; }

    public int? MovieId { get; set; }

    public int? TvShowId { get; set; }

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual TvShow? TvShow { get; set; }
}
