using Action = Api.AgileProj.Data.Entity.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.AgileProj.Business.Dto.Actions;

namespace Api.AgileProj.Business.Mapper.Actions
{
    public static class ActionMapper
    {
        public static Action TransformCreateDtoToEntity(CreateActionDto CreateAction)
        {
            return new Action()
            {
                TitleAction = CreateAction.TitleAction,
                IsCompleted = CreateAction.IsCompleted,
                Idtask = CreateAction.idTask
            };
        }

        public static ReadActionDto TransformEntityToReadActionDto(Action action)
        {
            return new ReadActionDto()
            {
                Id = action.Id,
                TitleAction = action.TitleAction,
                IsCompleted = action.IsCompleted,
                idTask = action.Idtask,
                TaskTitle = action.IdtaskNavigation.TitleTask
            };
        }
    }
}
