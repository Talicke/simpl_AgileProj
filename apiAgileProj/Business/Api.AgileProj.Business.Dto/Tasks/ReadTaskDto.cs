using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Api.AgileProj.Data.Entity.Model.Action;


namespace Api.AgileProj.Business.Dto.Tasks
{
    public class ReadTaskDto : CreateTaskDto
    {
        public int Id { get; set; }

        public string Manager {  get; set; }

        public string ProjectName { get; set; }

        public ICollection<Action> Actions { get; set; }
    }
}
