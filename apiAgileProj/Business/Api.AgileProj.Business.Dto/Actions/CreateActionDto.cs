using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Dto.Actions
{
    public class CreateActionDto
    {
        public string TitleAction { get; set; }
        public bool? IsCompleted { get; set; }
        public int idTask { get; set; }
    }
}
