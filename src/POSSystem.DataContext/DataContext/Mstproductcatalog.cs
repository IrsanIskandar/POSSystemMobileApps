using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Mstproductcatalog
{
    public int Id { get; set; }

    public string Productcode { get; set; } = null!;

    public string Productname { get; set; } = null!;

    public string? Remarks { get; set; }

    public int? Unitid { get; set; }

    public int? Categoryid { get; set; }

    public decimal? Price { get; set; }

    public double? Stockinitial { get; set; }

    public double? Stockbalance { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateTime? Modifydate { get; set; }

    public string? Poductimagepath { get; set; }

    public virtual LookupProductCategory? Category { get; set; }

    public virtual LookupUnit? Unit { get; set; }
}
