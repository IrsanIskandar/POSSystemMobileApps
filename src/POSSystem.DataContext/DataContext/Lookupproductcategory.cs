using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Lookupproductcategory
{
    public int Id { get; set; }

    public string Categoryname { get; set; } = null!;

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string? Createdby { get; set; }

    public DateOnly Createddate { get; set; }

    public string? Categorycode { get; set; }

    public virtual ICollection<Mstproductcatalog> Mstproductcatalogs { get; set; } = new List<Mstproductcatalog>();
}
