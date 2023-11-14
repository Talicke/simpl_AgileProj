using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity.Model;
using Api.AgileProj.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Data.Repository
{
    public class TaskRepo : ITaskRepo
    {
        private readonly IAgileProjDBContext _dBContext;

        public TaskRepo(IAgileProjDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// Create a new Task
        /// </summary>
        /// <param name="taskToAdd">Task to add</param>
        /// <returns></returns>
        public async Task<Task> CreateTaskAsync(Task taskToAdd)
        {
            var elementAdded = await _dBContext.Tasks.AddAsync(taskToAdd).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Delete an Task
        /// </summary>
        /// <param name="taskToDelete"></param>
        /// <returns></returns>
        public async Task<Task> DeleteTaskAsync(Task taskToDelete)
        {
            var elementDeleted = _dBContext.Tasks.Remove(taskToDelete);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Update an Task
        /// </summary>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        public async Task<Task> UpdateTaskAsync(Task taskToUpdate)
        {
            var elementUpdated = _dBContext.Tasks.Update(taskToUpdate);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Get a list of Task
        /// </summary>
        /// <returns></returns>
        public async Task<List<Task>> GetTasksAsync()
        {
            return await _dBContext.Tasks
                .Include(x => x.IdaccountNavigation)
                .Include(x => x.IdprojectNavigation)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Get one Task by id
        /// </summary>
        /// <param name="TaskId">id of Task</param>
        /// <returns></returns>
        public async Task<Task> GetTaskByIdAsync(int TaskId)
        {
            return await _dBContext.Tasks
                .Include(x => x.IdaccountNavigation)
                .Include(x => x.IdprojectNavigation)
                .FirstOrDefaultAsync(x => x.Id == TaskId)
                .ConfigureAwait(false);
        }
    }
}
