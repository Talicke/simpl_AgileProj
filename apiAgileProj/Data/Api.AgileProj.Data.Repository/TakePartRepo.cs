using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity.Model;
using Api.AgileProj.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository
{
    public class TakePartRepo : ITakePartRepo
    {
        private readonly IAgileProjDBContext _dbContext;

        public TakePartRepo (IAgileProjDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create a new takePart
        /// </summary>
        /// <param name="takePartToAdd"></param>
        /// <returns></returns>
        public async Task<TakePart> CreateTakePartAsync(TakePart takePartToAdd)
        {
            var elementAdded = await _dbContext.TakeParts.AddAsync(takePartToAdd)
                .ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Delete a takePart
        /// </summary>
        /// <param name="takePartToDelete"></param>
        /// <returns></returns>
        public async Task<TakePart> DeleteTakePartAsync(TakePart takePartToDelete)
        {
            var elemenetDeleted = _dbContext.TakeParts
                .Remove(takePartToDelete);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return elemenetDeleted.Entity;
        }

        /// <summary>
        /// Return the list of takePart
        /// </summary>
        /// <returns></returns>
        public async Task<List<TakePart>> getTaskPartAsync()
        {
            return await _dbContext.TakeParts
                .Include(x => x.IdaccountNavigation)
                .Include(x => x.IdprojectNavigation)
                .ToListAsync().ConfigureAwait(false);
        }
        
        /// <summary>
        /// get the list of takePart by project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<TakePart>> getTakePartByIdProject(int projectId)
        {
            return await _dbContext.TakeParts
                .Include (x => x.IdprojectNavigation)
                .Include (x => x.IdaccountNavigation)
                .Where(x => x.Idproject == projectId)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// get list of takePart by account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<List<TakePart>> getTakePartByIdAccount(int accountId)
        {
            return await _dbContext.TakeParts
                .Include(x => x.IdaccountNavigation)
                .Include(x => x.IdprojectNavigation)
                .Where(x => x.Idaccount == accountId)
                .ToListAsync().ConfigureAwait(false);
        }

    }
}
