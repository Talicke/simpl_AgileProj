using Api.AgileProj.Business.Dto.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services.Contract
{
    public interface IProjectService
    {

        /// <summary>
        /// Return a list of project
        /// </summary>
        /// <returns></returns>
        Task<List<ReadProjectDto>> GetProjectAsync();

        /// <summary>
        /// Create a project
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<ReadProjectDto> CreateProjectAsync(CreateProjectDto projectDto);
    }
}
