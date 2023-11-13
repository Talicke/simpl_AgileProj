using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class Account
{
    public int IdAccount { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
