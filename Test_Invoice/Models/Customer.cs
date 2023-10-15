using System;
using System.Collections.Generic;

namespace Test_Invoice.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public bool? CustomerStatus { get; set; }

    public int CustomerTypeId { get; set; }

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
