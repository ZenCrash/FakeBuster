using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<ContentItem> ContentItems { get; set; } = new List<ContentItem>();

    public virtual Person Person { get; set; } = null!;
}
