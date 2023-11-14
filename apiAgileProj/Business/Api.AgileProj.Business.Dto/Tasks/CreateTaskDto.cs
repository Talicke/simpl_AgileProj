using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Dto.Tasks
{
    public class CreateTaskDto
    {
        public string TitleTask { get; set; }
        public string DescriptionTask { get; set; }
        public sbyte StatusTask { get; set; }
        public DateTime CreateAtTask { get; set; }
        public DateTime EndAtTask { get; set; }
        public int idAccount { get; set; }
        public int idProject { get; set; }
    }
}
