﻿using System;
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

    public int Idaccounts { get; set; }

    public int Idprojects { get; set; }
}