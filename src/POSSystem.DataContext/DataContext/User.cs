using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Emailaddress { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? Lastlogindate { get; set; }

    public bool Isconfirmationaccount { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateTime? Modifydate { get; set; }

    public int? Roleid { get; set; }

    public virtual LookupRole? Role { get; set; }

    public virtual ICollection<Trxorder> Trxorders { get; set; } = new List<Trxorder>();

    public virtual ICollection<Userdetail> Userdetails { get; set; } = new List<Userdetail>();
}
