using Api.AgileProj.Business.Dto.Actions;
using Api.AgileProj.Business.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.AgileProj.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _actionService;

        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }


        // GET: api/<ActionController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadActionDto>), 200)]
        public async Task<ActionResult> GetActionAsync()
        {
            var ActionDto = await _actionService.GetActionAsync().ConfigureAwait(false);
            return Ok(ActionDto);
        }

        // GET api/<ActionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ReadActionDto>), 200)]
        public async Task<ActionResult> GetActionByTask(int id)
        {
            var actionDto = await _actionService.GetActionByTaskAsync(id)
                .ConfigureAwait(false);
            return Ok(actionDto);
        }

        // POST api/<ActionController>
        [HttpPost]
        [ProducesResponseType(typeof(ReadActionDto), 200)]
        public async Task<ActionResult> CreateActionAsync([FromBody] CreateActionDto actionDto)
        {
            if (string.IsNullOrWhiteSpace(actionDto?.TitleAction))
            {
                return BadRequest(new
                {
                    Error = "L'action doit avoir un titre"
                });

            }
            try
            {
                var elementAdded = await _actionService.CreateActionAsync(actionDto)
                    .ConfigureAwait(false);
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
        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
