﻿using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class LookupUnit
{
    public int Id { get; set; }

    public string Unitname { get; set; } = null!;

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string? Createby { get; set; }

    public DateTime Createddate { get; set; }

    public virtual ICollection<Mstproductcatalog> Mstproductcatalogs { get; set; } = new List<Mstproductcatalog>();
}
