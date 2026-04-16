using System;
using System.Collections.Generic;

namespace FakeBuster.DataAccess.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
