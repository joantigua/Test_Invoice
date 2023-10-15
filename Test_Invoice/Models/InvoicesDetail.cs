using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public partial class InvoicesDetail
{
    [Display(Name = "Id")]
    public int InvoiceDetailId { get; set; }
    [Display(Name = "Invoice Id")]
    public int CustomerId { get; set; }
    [Display(Name = "Quantity")]
    public int InvoiceDetailQuantity { get; set; }
    [Display(Name = "Price")]
    public decimal InvoiceDetailPrice { get; set; }
    [Display(Name = "Total ITBIS")]
    public decimal InvoiceDetailTotalItbis { get; set; }
    [Display(Name = "Sub Total")]
    public decimal InvoiceDetailSubtotal { get; set; }
    [Display(Name = "Total")]
    public decimal InvoiceDetailTotal { get; set; }

    public virtual Invoice Customer { get; set; } = null!;
}
