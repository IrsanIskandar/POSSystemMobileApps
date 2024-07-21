using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Customer
{
    public int Id { get; set; }

    public string Customername { get; set; } = null!;

    public int? Genderid { get; set; }

    public string? Address { get; set; }

    public int? Mobilephone { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateTime? Modifydate { get; set; }

    public virtual Admindatasetup? Gender { get; set; }

    public virtual ICollection<Trxorder> Trxorders { get; set; } = new List<Trxorder>();

    public virtual ICollection<Trxpayment> Trxpayments { get; set; } = new List<Trxpayment>();
}
