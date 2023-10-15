using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public partial class CustomerType
{
    [Display(Name = "Id")]
    public int CustomerTypeId { get; set; }
    [Display(Name = "Description")]
    public string CustomerTypeDescription { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
