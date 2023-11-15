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
    public class ProjetRepo : IProjectRepo
    {
        private readonly IAgileProjDBContext _dBContext;

        public ProjetRepo(IAgileProjDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// Create a new Project
        /// </summary>
        /// <param name="projectToAdd">Project to add</param>
        /// <returns></returns>
        public async Task<Project> CreateProjectAsync(Project projectToAdd)
        {
            var elementAdded = await _dBContext.Projects.AddAsync(projectToAdd).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Delete an Project
        /// </summary>
        /// <param name="projectToDelete"></param>
        /// <returns></returns>
        public async Task<Project> DeleteProjectAsyn(Project projectToDelete)
        {
            var elementDeleted = _dBContext.Projects.Remove(projectToDelete);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Update an Project
        /// </summary>
        /// <param name="projectToUpdate"></param>
        /// <returns></returns>
        public async Task<Project> UpdateProjectAsyn(Project projectToUpdate)
        {
            var elementUpdated = _dBContext.Projects.Update(projectToUpdate);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Get a list of Project
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _dBContext.Projects.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Get one Project by id
        /// </summary>
        /// <param name="projectId">id of Project</param>
        /// <returns></returns>
        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _dBContext.Projects
                .FirstOrDefaultAsync(x => x.Id == projectId)
                .ConfigureAwait(false);
        }
    }
}
