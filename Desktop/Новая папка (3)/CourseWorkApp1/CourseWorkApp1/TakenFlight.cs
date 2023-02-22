using System;
using System.Collections.Generic;

namespace CourseWorkApp1;

public partial class TakenFlight
{
    public long Id { get; set; }

    public string? Status { get; set; }

    public long? Quantity { get; set; }

    public long? UserIdCheck { get; set; }

    public long? FlightId { get; set; }

    public string? CityName { get; set; }

    public string? Time { get; set; }

    public string? Date { get; set; }

    public long? Price { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual User? UserIdCheckNavigation { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
