using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class Task
{
    public int Id { get; set; }

    public string TitleTask { get; set; } = null!;

    public string DescriptionTask { get; set; } = null!;

    public sbyte StatusTask { get; set; }

    public DateTime CreatedAtTask { get; set; }

    public DateTime EndAtTask { get; set; }

    public int Idaccount { get; set; }

    public int Idproject { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Account IdaccountNavigation { get; set; } = null!;

    public virtual Project IdprojectNavigation { get; set; } = null!;
}
