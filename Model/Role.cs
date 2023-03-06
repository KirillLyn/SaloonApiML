﻿using System;
using System.Collections.Generic;

namespace SaloonApiML.Model;

public partial class Role
{
    public int Id { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
