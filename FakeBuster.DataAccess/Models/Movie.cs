using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? DurationMinutes { get; set; }

    public int? ContentItemId { get; set; }

    public virtual ContentItem? ContentItem { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
