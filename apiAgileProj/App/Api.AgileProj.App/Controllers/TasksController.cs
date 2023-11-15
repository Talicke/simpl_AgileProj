using Api.AgileProj.Business.Dto.Tasks;
using Api.AgileProj.Business.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.AgileProj.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController (ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get the list of task
        /// </summary>
        /// <returns></returns>
        // GET: api/<TasksController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadTaskDto>), 200)]
        public async Task<ActionResult> GetTaksAsync()
        {
            var taskDto = await _taskService.GetTaskAsync().ConfigureAwait(false);
            return Ok(taskDto);
        }

        // POST api/<TasksController>
        [HttpPost]
        [ProducesResponseType(typeof(ReadTaskDto), 200)]
        public async Task<ActionResult> CreateTaskAsync([FromBody] CreateTaskDto taskDto)
        {
            if (string.IsNullOrWhiteSpace(taskDto?.TitleTask) || string.IsNullOrWhiteSpace(taskDto?.DescriptionTask))
            {
                return BadRequest(new 
                { 
                    Error = "les informations sont imcomplète"
                });
            }

            try
            {
            var elementAdded = await _taskService.CreateTaskAsync(taskDto).ConfigureAwait(false);
            return Ok(elementAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }

        }

        /*
        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
