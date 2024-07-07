using System;
using System.Collections.Generic;

namespace POSSystem.DataContext.DataContext;

public partial class Admindatasetup
{
    public int Id { get; set; }

    public string Nameeng { get; set; } = null!;

    public string? Nameidn { get; set; }

    public int? Parentid { get; set; }

    public string? Remarks { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string Createdby { get; set; } = null!;

    public DateOnly Createddate { get; set; }

    public string? Modifyby { get; set; }

    public DateOnly? Modifydate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Trxorder> Trxorders { get; set; } = new List<Trxorder>();

    public virtual ICollection<Trxpayment> Trxpayments { get; set; } = new List<Trxpayment>();

    public virtual ICollection<Userdetail> Userdetails { get; set; } = new List<Userdetail>();
}
