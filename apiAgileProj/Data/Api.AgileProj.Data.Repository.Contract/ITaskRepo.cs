using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository.Contract
{
    public interface ITaskRepo
    {
        /// <summary>
        /// Create a new Task
        /// </summary>
        /// <param name="taskToAdd">Task to add</param>
        /// <returns></returns>
        Task<Task> CreateTaskAsync(Task taskToAdd);

        /// <summary>
        /// Delete an Task
        /// </summary>
        /// <param name="taskToDelete"></param>
        /// <returns></returns>
        Task<Task> DeleteTaskAsyn(Task taskToDelete);

        /// <summary>
        /// Update an Task
        /// </summary>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        Task<Task> UpdateTaskAsyn(Task taskToUpdate);

        /// <summary>
        /// Get a list of Task
        /// </summary>
        /// <returns></returns>
        Task<List<Task>> GetTasksAsync();

        /// <summary>
        /// Get one Task by id
        /// </summary>
        /// <param name="TaskId">id of Task</param>
        /// <returns></returns>
        Task<Task> GetTaskByIdAsync(int TaskId);
    }
}
