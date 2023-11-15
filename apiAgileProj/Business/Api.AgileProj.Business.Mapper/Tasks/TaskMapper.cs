using Api.AgileProj.Business.Dto.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Business.Mapper.Tasks
{
    public static class TaskMapper
    {
        /// <summary>
        /// Transfrom a TaskDto to Task Entity
        /// </summary>
        /// <param name="createTask"></param>
        /// <returns></returns>
        public static Task TransformCreateDtoToEntity(CreateTaskDto createTask)
        {
            return new Task()
            {
                TitleTask = createTask.TitleTask,
                DescriptionTask = createTask.DescriptionTask,
                StatusTask = createTask.StatusTask,
                CreatedAtTask = createTask.CreateAtTask,
                EndAtTask = createTask.EndAtTask,
                Idaccount = createTask.idAccount,
                Idproject = createTask.idProject,

            };
        }

        /// <summary>
        /// Transform a task entity to taskDto
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static ReadTaskDto TransformEntityToReadTaskDto(Task task)
        {
            return new ReadTaskDto()
            {
                Id = task.Id,
                TitleTask = task.TitleTask,
                DescriptionTask = task.DescriptionTask,
                StatusTask = task.StatusTask,
                CreateAtTask = task.CreatedAtTask,
                EndAtTask = task.EndAtTask,
                idAccount = task.Idaccount,
                idProject = task.Idproject,
                ProjectName = task.IdprojectNavigation.NameProject,
                Manager = task.IdaccountNavigation.Username,
                Actions = task.Actions

            };
        }
    }
}
