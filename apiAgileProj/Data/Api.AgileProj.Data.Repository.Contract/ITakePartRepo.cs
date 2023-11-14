using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository.Contract
{
    public interface ITakePartRepo
    {

        /// <summary>
        /// Create a new takePart
        /// </summary>
        /// <param name="takePartToAdd"></param>
        /// <returns></returns>
        Task<TakePart> CreateTakePartAsync(TakePart takePartToAdd);

        /// <summary>
        /// Delete a takePart
        /// </summary>
        /// <param name="takePartToDelete"></param>
        /// <returns></returns>
       Task<TakePart> DeleteTakePartAsync(TakePart takePartToDelete);

        /// <summary>
        /// Return the list of takePart
        /// </summary>
        /// <returns></returns>
        Task<List<TakePart>> getTaskPartAsync();
        /// <summary>
        /// get the list of takePart by project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<List<TakePart>> getTakePartByIdProject(int projectId);

        /// <summary>
        /// get list of takePart by account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<List<TakePart>> getTakePartByIdAccount(int accountId);
    }

}
