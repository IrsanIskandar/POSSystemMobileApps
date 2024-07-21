using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Trxpayment
{
    public int Id { get; set; }

    public int Customerid { get; set; }

    public int Orderid { get; set; }

    public int? Paymenttypeid { get; set; }

    public decimal? Totalamount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Trxorder Order { get; set; } = null!;

    public virtual Admindatasetup? Paymenttype { get; set; }
}
