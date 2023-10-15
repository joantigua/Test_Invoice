using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public partial class Invoice
{
    [Display(Name = "Id")]
    public int InvoiceId { get; set; }
    [Display(Name = "Customer Name")]
    public int CustomerId { get; set; }
    [Display(Name = "Total ITBIS")]
    public decimal InvoiceTotalItbis { get; set; }
    [Display(Name = "Sub Total")]
    public decimal InvoiceSubtotal { get; set; }
    [Display(Name = "Total")]
    public decimal InvoiceTotal { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
