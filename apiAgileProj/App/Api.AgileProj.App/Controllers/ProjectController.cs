using Api.AgileProj.Business.Dto.Projects;
using Api.AgileProj.Business.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.AgileProj.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController (IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// get the list of project
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProjectController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadProjectDto>), 200)]
        public async Task<ActionResult> GetProjectAsync()
        {
            var projectDto = await _projectService.GetProjectAsync().ConfigureAwait(false);
            return Ok(projectDto);
        }


        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        // POST api/<ProjectController>
        [HttpPost]
        [ProducesResponseType(typeof(ReadProjectDto), 200)]
        public async Task<ActionResult> CreateProjectAsync([FromBody] CreateProjectDto projectDto)
        {
            if (string.IsNullOrWhiteSpace(projectDto?.NameProject))
            {
                return BadRequest(new
                {
                    Error = "Information incomplète"
                });
            }

            try
            {
                var elementAdded = await _projectService.CreateProjectAsync(projectDto)
                    .ConfigureAwait(false);
                return Ok(elementAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    Error = ex.Message 
                });
            }
        }

        /*
        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
