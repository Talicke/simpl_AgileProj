using Api.AgileProj.Business.Dto.TakeParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services.Contract
{
    public interface ITakePartService
    {
        /// <summary>
        /// Return a list of projectId by AccountId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<List<ReadTakePartDto>> GetTakePartByAccountAsync(int accountId);

        /// <summary>
        /// Associate an Account to a project
        /// </summary>
        /// <param name="takePartDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadTakePartDto> CreateTakePartAsync(CreateTakePartDto takePartDto);
    }
}
