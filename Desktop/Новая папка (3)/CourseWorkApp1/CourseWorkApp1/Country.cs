using System;
using System.Collections.Generic;

namespace CourseWorkApp1;

public partial class Country
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Picture { get; set; }

    public string? Distance { get; set; }

    public string? Status { get; set; }

    public string? Distinguishments { get; set; }

    public string? Language { get; set; }

    public string? Information { get; set; }

    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();
}
