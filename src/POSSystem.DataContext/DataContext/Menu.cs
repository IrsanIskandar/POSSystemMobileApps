using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Menu
{
    public int Id { get; set; }

    public string Menuname { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateOnly Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateOnly? Modifydate { get; set; }

    public virtual ICollection<Trxorder> Trxorders { get; set; } = new List<Trxorder>();
}
