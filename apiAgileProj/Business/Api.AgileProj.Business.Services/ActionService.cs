using Api.AgileProj.Business.Dto.Actions;
using Api.AgileProj.Business.Mapper.Actions;
using Api.AgileProj.Business.Services.Contract;
using Api.AgileProj.Data.Entity.Model;
using Api.AgileProj.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepo _actionRepo;
        private readonly ITaskRepo _taskRepo;

        public ActionService(IActionRepo actionRepo, ITaskRepo taskRepo)
        {
            _actionRepo = actionRepo;
            _taskRepo = taskRepo;
        }

        /// <summary>
        /// Return all Actions
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadActionDto>> GetActionAsync()
        {
            var actions = await _actionRepo.GetActionsAsync()
                .ConfigureAwait(false);
            List<ReadActionDto> readActionDtos = new List<ReadActionDto>();

            foreach (var action in actions)
            {
                readActionDtos.Add(ActionMapper.TransformEntityToReadActionDto(action));                
            }
            return readActionDtos;
        }

        /// <summary>
        /// Return action of tickets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ReadActionDto>> GetActionByTaskAsync(int id)
        {
            var actions = await _actionRepo.GetActionByIdTaskAsync(id)
                .ConfigureAwait(false);
            List<ReadActionDto> readActionDtos = new List<ReadActionDto>();

            foreach (var action in actions)
            {
                readActionDtos.Add(ActionMapper.TransformEntityToReadActionDto(action));
            }
            return readActionDtos;
        }

        /// <summary>
        /// Create an action
        /// </summary>
        /// <param name="ActionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadActionDto>CreateActionAsync(CreateActionDto ActionDto)
        {
            if (ActionDto == null)
            {
                throw new ArgumentNullException(nameof(ActionDto));
            }

            //Verify task exist
            var task = await _taskRepo.GetTaskByIdAsync(ActionDto.idTask)
                .ConfigureAwait(false);

            if(task != null)
            {
                throw new Exception("Le ticket n'existe pas");
            }

            var actionToAdd = ActionMapper.TransformCreateDtoToEntity(ActionDto);
            var actionAdded = await _actionRepo.CreateActionAsync(actionToAdd).ConfigureAwait(false);

            return ActionMapper.TransformEntityToReadActionDto(actionAdded);
        }
    }
}
