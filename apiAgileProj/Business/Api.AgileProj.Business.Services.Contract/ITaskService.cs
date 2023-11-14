using Api.AgileProj.Business.Dto.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services.Contract
{
    public interface ITaskService
    {


        /// <summary>
        /// Retun a list of task
        /// </summary>
        /// <returns></returns>
        Task<List<ReadTaskDto>> GetTaskAsync();

        /// <summary>
        /// Create a task
        /// </summary>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadTaskDto> CreateTaskAsync(CreateTaskDto taskDto);
    }
}
