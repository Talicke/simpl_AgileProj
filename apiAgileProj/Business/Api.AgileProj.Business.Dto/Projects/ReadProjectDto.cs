﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Business.Dto.Projects
{
    public class ReadProjectDto : CreateProjectDto
    {
        public int Id { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
