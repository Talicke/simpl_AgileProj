using Api.AgileProj.Business.Dto.Tasks;
using Api.AgileProj.Business.Mapper.Tasks;
using Api.AgileProj.Business.Services.Contract;
using Api.AgileProj.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;
        private readonly IAccountRepo _accountRepo;
        private readonly IProjectRepo _projetRepo;
        
        public TaskService(ITaskRepo taskrepo, IAccountRepo accountRepo, IProjectRepo projetRepo)
        {
            _taskRepo = taskrepo;
            _accountRepo = accountRepo;
            _projetRepo = projetRepo;
        }
        /// <summary>
        /// Retun a list of task
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadTaskDto>> GetTaskAsync()
        {
            var tasks = await _taskRepo.GetTasksAsync().ConfigureAwait(false);
            List<ReadTaskDto> readTaskDtos = new List<ReadTaskDto>();

            foreach (var task in tasks)
            {
                readTaskDtos.Add(TaskMapper.TransformEntityToReadTaskDto(task));
            }
            return readTaskDtos;
        }

        /// <summary>
        /// Create a task
        /// </summary>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadTaskDto> CreateTaskAsync(CreateTaskDto taskDto)
        {
            if(taskDto == null)
            {
                throw new ArgumentNullException(nameof(taskDto));
            }

            //vérify id account is valid
            var account = await _accountRepo.GetAccountByIdAsync(taskDto.idAccount).ConfigureAwait(false);

            if(account == null)
            {
                throw new Exception($"Echec de la création du ticket, le responsable n'existe pas = {taskDto.idAccount} ");
            }

            //vérify id projet is valid
            var project = await _projetRepo.GetProjectByIdAsync(taskDto.idProject).ConfigureAwait(false);

            if(project == null)
            {
                throw new Exception($"Echec de la création du ticket, le projet est introuvable = {taskDto.idProject}");
            }

            var taskToAdd = TaskMapper.TransformCreateDtoToEntity(taskDto);
            var taskAdded = await _taskRepo.CreateTaskAsync(taskToAdd).ConfigureAwait(false);

            return TaskMapper.TransformEntityToReadTaskDto(taskAdded);



        }
    }
}
