using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class Project
{
    public int IdProject { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime CreatedAtProject { get; set; }
}
