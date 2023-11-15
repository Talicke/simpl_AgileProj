using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository.Contract
{
    public interface IProjectRepo
    {
        /// <summary>
        /// Create a new Project
        /// </summary>
        /// <param name="projectToAdd">Project to add</param>
        /// <returns></returns>
        Task<Project> CreateProjectAsync(Project projectToAdd);

        /// <summary>
        /// Delete an Project
        /// </summary>
        /// <param name="projectToDelete"></param>
        /// <returns></returns>
        Task<Project> DeleteProjectAsyn(Project projectToDelete);

        /// <summary>
        /// Update an Project
        /// </summary>
        /// <param name="projectToUpdate"></param>
        /// <returns></returns>
        Task<Project> UpdateProjectAsyn(Project projectToUpdate);

        /// <summary>
        /// Get a list of Project
        /// </summary>
        /// <returns></returns>
        Task<List<Project>> GetProjectsAsync();

        /// <summary>
        /// Get one Project by id
        /// </summary>
        /// <param name="projectId">id of Project</param>
        /// <returns></returns>
        Task<Project> GetProjectByIdAsync(int projectId);
    }
}
