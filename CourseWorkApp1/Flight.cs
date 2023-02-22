using System;
using System.Collections.Generic;

namespace CourseWorkApp1;

public partial class Flight
{
    public long Id { get; set; }

    public long? AmountOfPlaces { get; set; }

    public long? GeneralAmountOfPlaces { get; set; }

    public long? IsTaken { get; set; }

    public string CityName { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string? DateTime { get; set; }

    public long Price { get; set; }

    public long? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<TakenFlight> TakenFlights { get; } = new List<TakenFlight>();
}
