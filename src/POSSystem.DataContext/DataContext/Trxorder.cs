using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Trxorder
{
    public int Id { get; set; }

    public string Ordercode { get; set; } = null!;

    public int Customerid { get; set; }

    public int Userid { get; set; }

    public int Menuid { get; set; }

    public int? Orderstatusid { get; set; }

    public DateOnly? Orderdate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual Admindatasetup? Orderstatus { get; set; }

    public virtual ICollection<Trxpayment> Trxpayments { get; set; } = new List<Trxpayment>();

    public virtual User User { get; set; } = null!;
}
