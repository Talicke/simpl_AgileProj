using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class Project
{
    public int Id { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime CreatedAtProject { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
