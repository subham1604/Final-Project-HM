using System;
using System.Collections.Generic;

namespace BookingAPI.Models;

public partial class Booking
{
    public int? UserId { get; set; }

    public int? HotelId { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public string? BookingStatus { get; set; }

    public string BookingId { get; set; } = null!;

    public DateTime? BookingDate { get; set; }

    public virtual UserDetail? User { get; set; }
}
