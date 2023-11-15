using Api.AgileProj.Business.Dto.TakeParts;
using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Mapper.TakeParts
{
    public static class TakePartMapper
    {
        /// <summary>
        /// Transform a TakePartDto to takePart Entity
        /// </summary>
        /// <param name="createTakePart"></param>
        /// <returns></returns>
        public static TakePart TransformCreateTakePartDtoToEntity(CreateTakePartDto createTakePart)
        {
            return new TakePart()
            {
                Idaccount = createTakePart.IdAccount,
                Idproject = createTakePart.idProject
            };
        }

        /// <summary>
        /// Transform a TakePart Entity to TakePartDto
        /// </summary>
        /// <param name="takePart"></param>
        /// <returns></returns>
        public static ReadTakePartDto TransformEntityToReadTakePartDto(TakePart takePart)
        {
            return new ReadTakePartDto()
            {
                IdAccount = takePart.Idaccount,
                idProject = takePart.Idproject,
                ProjectName = takePart.IdprojectNavigation.NameProject,
                AccountUsername = takePart.IdaccountNavigation.Username
            };
        }
        
    }
}
