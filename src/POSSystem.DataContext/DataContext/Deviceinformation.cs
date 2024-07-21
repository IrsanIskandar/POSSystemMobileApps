using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Deviceinformation
{
    public int Id { get; set; }

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public string? Devicename { get; set; }

    public string? Osversion { get; set; }

    public string? Idiom { get; set; }

    public string? Platform { get; set; }

    public string? Devicetype { get; set; }

    public DateTime Createddate { get; set; }
}
