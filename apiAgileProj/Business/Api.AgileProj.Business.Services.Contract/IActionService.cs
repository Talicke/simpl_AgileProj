using Api.AgileProj.Business.Dto.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services.Contract
{
    public interface IActionService
    {
        /// <summary>
        /// Return all Actions
        /// </summary>
        /// <returns></returns>
        Task<List<ReadActionDto>> GetActionAsync();

        /// <summary>
        /// Return action of tickets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ReadActionDto>> GetActionByTaskAsync(int id);

        /// <summary>
        /// Create an action
        /// </summary>
        /// <param name="ActionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadActionDto> CreateActionAsync(CreateActionDto ActionDto);
    }
}
