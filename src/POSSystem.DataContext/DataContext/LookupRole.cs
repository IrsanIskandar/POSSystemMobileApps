using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class LookupRole
{
    public int Id { get; set; }

    public string Rolename { get; set; } = null!;

    public string? Roledescription { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Createdate { get; set; }

    public bool Isactive { get; set; }

    public virtual ICollection<LookupModule> LookupModules { get; set; } = new List<LookupModule>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
