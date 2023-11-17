using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Business.Dto.Accounts
{
    public class ReadAccountDto : CreateAccountDto
    {
        public int Id { get; set; }
    }
}
