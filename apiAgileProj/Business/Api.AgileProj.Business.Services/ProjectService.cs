using Api.AgileProj.Business.Dto.Projects;
using Api.AgileProj.Business.Mapper.Projects;
using Api.AgileProj.Business.Services.Contract;
using Api.AgileProj.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo projectRepo )
        {
            _projectRepo = projectRepo;
        }

        /// <summary>
        /// Return a list of project
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadProjectDto>> GetProjectAsync()
        {
            var projects = await _projectRepo.GetProjectsAsync()
                .ConfigureAwait(false);
            List<ReadProjectDto> readProjectDtos = new List<ReadProjectDto>();

            foreach ( var project in projects )
            {
                readProjectDtos.Add(ProjectMapper.TransformEntityToReadDto(project));
            }
            return readProjectDtos;
        }

        /// <summary>
        /// Create a project
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ReadProjectDto> CreateProjectAsync(CreateProjectDto projectDto)
        {
            if(projectDto == null)
            {
                throw new ArgumentNullException(nameof(projectDto));
            }

            var projectToAdd = ProjectMapper.TransformCreateProjectDtoToEntity(projectDto);
            var projectAdded = await _projectRepo.CreateProjectAsync(projectToAdd);

            return ProjectMapper.TransformEntityToReadDto(projectAdded);
        }
    }
}
