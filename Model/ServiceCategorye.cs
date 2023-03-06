using System;
using System.Collections.Generic;

namespace SaloonApiML.Model;

public partial class ServiceCategoryes
{
    public int CategoryId { get; set; }

    public string? CategoryTitle { get; set; }

    public byte[]? CategoryImage { get; set; }

    public virtual ICollection<Services> Services { get; } = new List<Services>();
}
