using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity.Model;
using Api.AgileProj.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Api.AgileProj.Data.Entity.Model.Action;

namespace Api.AgileProj.Data.Repository
{
    public class ActionRepo : IActionRepo
    {

        private readonly IAgileProjDBContext _dBContext;

        public ActionRepo(IAgileProjDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// Create a new Action
        /// </summary>
        /// <param name="actionToAdd">Action to add</param>
        /// <returns></returns>
        public async Task<Action> CreateActionAsync(Action actionToAdd)
        {
            var elementAdded = await _dBContext.Actions.AddAsync(actionToAdd).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Delete an Action
        /// </summary>
        /// <param name="actionToDelete"></param>
        /// <returns></returns>
        public async Task<Action> DeleteActionAsyn(Action actionToDelete)
        {
            var elementDeleted = _dBContext.Actions.Remove(actionToDelete);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Update an Action
        /// </summary>
        /// <param name="actionToUpdate"></param>
        /// <returns></returns>
        public async Task<Action> UpdateActionAsyn(Action actionToUpdate)
        {
            var elementUpdated = _dBContext.Actions.Update(actionToUpdate);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Get a list of Action
        /// </summary>
        /// <returns></returns>
        public async Task<List<Action>> GetActionsAsync()
        {
            return await _dBContext.Actions
                .Include(x => x.IdtaskNavigation)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// get the list of takePart by project
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<List<Action>> GetActionByIdTaskAsync(int taskId)
        {
            return await _dBContext.Actions
                .Include (x => x.IdtaskNavigation)
                .Where(x => x.Idtask == taskId)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Get one Action by id
        /// </summary>
        /// <param name="accountId">id of Action</param>
        /// <returns></returns>
        public async Task<Action> GetActionByIdAsync(int actionId)
        {
            return await _dBContext.Actions
                .Include(x => x.IdtaskNavigation)
                .FirstOrDefaultAsync(x => x.Id == actionId)
                .ConfigureAwait(false);
        }

    }
}
