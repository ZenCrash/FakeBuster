using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<TvShow> TvShows { get; set; } = new List<TvShow>();
}
