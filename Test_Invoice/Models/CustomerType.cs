using System;
using System.Collections.Generic;

namespace Test_Invoice.Models;

public partial class CustomerType
{
    public int CustomerTypeId { get; set; }

    public string CustomerTypeDescription { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
