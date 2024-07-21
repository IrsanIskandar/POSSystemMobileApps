using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class LookupModule
{
    public int Id { get; set; }

    public string Modulename { get; set; } = null!;

    public string? Moduleicon { get; set; }

    public string? Moduledescription { get; set; }

    public int? Parentmoduleid { get; set; }

    public bool? Isparent { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Roleid { get; set; }

    public bool Ismultipleitems { get; set; }

    public string? Contenttemplate { get; set; }

    public virtual LookupRole? Role { get; set; }
}
