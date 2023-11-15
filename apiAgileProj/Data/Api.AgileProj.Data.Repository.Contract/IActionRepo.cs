using Action = Api.AgileProj.Data.Entity.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository.Contract
{
    public interface IActionRepo
    {
        /// <summary>
        /// Create a new Action
        /// </summary>
        /// <param name="actionToAdd">Action to add</param>
        /// <returns></returns>
        Task<Action> CreateActionAsync(Action actionToAdd);

        /// <summary>
        /// Delete an Action
        /// </summary>
        /// <param name="actionToDelete"></param>
        /// <returns></returns>
       Task<Action> DeleteActionAsyn(Action actionToDelete);

        /// <summary>
        /// Update an Action
        /// </summary>
        /// <param name="actionToUpdate"></param>
        /// <returns></returns>
        Task<Action> UpdateActionAsyn(Action actionToUpdate);

        /// <summary>
        /// Get a list of Action
        /// </summary>
        /// <returns></returns>
        Task<List<Action>> GetActionsAsync();

        /// <summary>
        /// Get one Action by id
        /// </summary>
        /// <param name="accountId">id of Action</param>
        /// <returns></returns>
        Task<Action> GetActionByIdAsync(int actionId);

        /// <summary>
        /// get the list of takePart by project
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<List<Action>> GetActionByIdTaskAsync(int taskId);
    }
}
