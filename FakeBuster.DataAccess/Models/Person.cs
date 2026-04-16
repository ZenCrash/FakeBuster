using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public int AddressId { get; set; }

    public bool? DeactivatedUser { get; set; }

    public virtual Address Address { get; set; } = new Address();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
