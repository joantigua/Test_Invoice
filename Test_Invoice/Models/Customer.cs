using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public partial class Customer
{
    [Display(Name = "Id")]
    public int CustomerId { get; set; }
    [Display (Name = "Name")]
    public string CustomerName { get; set; } = null!;
    [Display(Name = "Address")]
    public string CustomerAddress { get; set; } = null!;
    [Display(Name = "Status")]
    public bool? CustomerStatus { get; set; }
    [Display(Name = "Customer Type")]
    public int CustomerTypeId { get; set; }

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
