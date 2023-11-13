using System;
using System.Collections.Generic;

namespace Api.AgileProj.Data.Entity.Model;

public partial class TakePart
{
    public int Idaccount { get; set; }

    public int Idproject { get; set; }

    public virtual Account IdaccountNavigation { get; set; } = null!;

    public virtual Project IdprojectNavigation { get; set; } = null!;
}
