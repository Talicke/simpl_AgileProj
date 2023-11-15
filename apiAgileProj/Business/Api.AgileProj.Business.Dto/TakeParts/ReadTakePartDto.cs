using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Dto.TakeParts
{
    public class ReadTakePartDto : CreateTakePartDto
    {
        public string AccountUsername { get; set; }
        public string ProjectName { get; set; }
    }
}
