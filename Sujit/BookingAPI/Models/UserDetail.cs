using System;
using System.Collections.Generic;

namespace BookingAPI.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? AdharNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
