using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class TvShow
{
    public int Id { get; set; }

    public int EpisodeCount { get; set; }

    public int SeasonNumber { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? DurationMinutes { get; set; }

    public virtual ICollection<ContentItem> ContentItems { get; set; } = new List<ContentItem>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
