using System;
using System.Collections.Generic;

namespace Test_Invoice.Models;

public partial class InvoicesDetail
{
    public int InvoiceDetailId { get; set; }

    public int CustomerId { get; set; }

    public int InvoiceDetailQuantity { get; set; }

    public decimal InvoiceDetailPrice { get; set; }

    public decimal InvoiceDetailTotalItbis { get; set; }

    public decimal InvoiceDetailSubtotal { get; set; }

    public decimal InvoiceDetailTotal { get; set; }

    public virtual Invoice Customer { get; set; } = null!;
}
