using Api.AgileProj.Business.Dto.TakeParts;
using Api.AgileProj.Business.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.AgileProj.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakePartController : ControllerBase
    {
        private readonly ITakePartService _takePartService;

        public TakePartController(ITakePartService takePartService)
        {
            _takePartService = takePartService;
        }

        /// <summary>
        /// Get the list of project by id account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<TakePartController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ReadTakePartDto>), 200)]
        public async Task<ActionResult> GetTakePartByAccountId(int id)
        {
            var takePartDto = await _takePartService.GetTakePartByAccountAsync(id)
                .ConfigureAwait(false);
            return Ok(takePartDto);
        }

        /// <summary>
        /// create a takePart
        /// </summary>
        /// <param name="takePartDto"></param>
        /// <returns></returns>
        // POST api/<TakePartController>
        [HttpPost]
        [ProducesResponseType(typeof(ReadTakePartDto), 200)]
        public async Task<ActionResult> CreateTakePartAsync([FromBody] CreateTakePartDto takePartDto)
        {
            try
            {
                var elementAdded = await _takePartService.CreateTakePartAsync(takePartDto)
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
        // GET: api/<TakePartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // PUT api/<TakePartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TakePartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
