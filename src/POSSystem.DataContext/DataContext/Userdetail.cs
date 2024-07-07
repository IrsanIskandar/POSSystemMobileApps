using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Userdetail
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string? Nikorpassport { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string? Fulladdress { get; set; }

    public int? Genderid { get; set; }

    public string? Mobilephone { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateTime? Modifydate { get; set; }

    public virtual Admindatasetup? Gender { get; set; }

    public virtual User User { get; set; } = null!;
}
