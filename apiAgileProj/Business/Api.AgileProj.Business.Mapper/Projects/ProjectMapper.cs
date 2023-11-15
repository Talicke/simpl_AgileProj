using Api.AgileProj.Business.Dto.Projects;
using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Mapper.Projects
{
    public static class ProjectMapper
    {
        /// <summary>
        /// Transform a ProjectDto to project entity
        /// </summary>
        /// <param name="CreateProject"></param>
        /// <returns></returns>
        public static Project TransformCreateProjectDtoToEntity(CreateProjectDto CreateProject)
        {
            return new Project()
            {
                NameProject = CreateProject.NameProject,
                CreatedAtProject = CreateProject.createdAtProject
            };
        }

        /// <summary>
        /// Transform a Project entity to ProjectDto
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static ReadProjectDto TransformEntityToReadDto(Project project)
        {
            return new ReadProjectDto()
            {
                Id = project.Id,
                NameProject = project.NameProject,
                createdAtProject = project.CreatedAtProject,
                Tasks = project.Tasks,
            };
        }
    }
}
