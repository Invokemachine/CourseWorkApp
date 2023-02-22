using System;
using System.Collections.Generic;

namespace CourseWorkApp1;

public partial class User
{
    public long Id { get; set; }

    public long? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public long? UserTakenTickets { get; set; }

    public long? PassportId { get; set; }

    public long? PassportSeries { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Citizenship { get; set; }

    public virtual ICollection<TakenFlight> TakenFlights { get; } = new List<TakenFlight>();

    public virtual TakenFlight? UserTakenTicketsNavigation { get; set; }
}
