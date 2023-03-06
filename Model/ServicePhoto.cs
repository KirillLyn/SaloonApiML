using System;
using System.Collections.Generic;

namespace SaloonApiML.Model;

public partial class ServicePhoto
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public virtual Services Service { get; set; } = null!;
}
