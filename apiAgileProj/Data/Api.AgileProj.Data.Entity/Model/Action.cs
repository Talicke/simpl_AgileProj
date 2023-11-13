using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class Action
{
    public int Id { get; set; }

    public string TitleAction { get; set; } = null!;

    public bool? IsCompleted { get; set; }

    public int Idtask { get; set; }

    public virtual Task IdtaskNavigation { get; set; } = null!;
}
