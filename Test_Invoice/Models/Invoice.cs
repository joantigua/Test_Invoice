using System;
using System.Collections.Generic;

namespace Test_Invoice.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int CustomerId { get; set; }

    public decimal InvoiceTotalItbis { get; set; }

    public decimal InvoiceSubtotal { get; set; }

    public decimal InvoiceTotal { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
