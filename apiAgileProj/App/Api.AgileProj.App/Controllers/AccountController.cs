using Api.AgileProj.Business.Dto.Accounts;
using Api.AgileProj.Business.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.AgileProj.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController (IAccountService accountService)
        {
            _accountService = accountService;
        }


        // GET: api/<AccountController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadAccountDto>), 200)]
        public async Task<ActionResult> GetAccountAsync()
        {
            var accountDto = await _accountService.GetAccountAsync().ConfigureAwait(false);
            return Ok(accountDto);
        }

        
        

        // POST api/<AccountController>
        [HttpPost]
        [ProducesResponseType(typeof(ReadAccountDto),200)]
        public async Task<ActionResult> CreateAccountAsync([FromBody] CreateAccountDto accountDto)
        {
            if(string.IsNullOrWhiteSpace(accountDto?.Username) || string.IsNullOrWhiteSpace(accountDto?.Password))
            {
                return BadRequest(new
                {
                    Error = "Informations incomplète"
                });
            }

            try
            {
                var elementAdded = await _accountService.CreateAccountAsync(accountDto).ConfigureAwait(false);
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

        
        // GET api/<AccountController>/5
        [HttpGet("{username}")]
        [ProducesResponseType(typeof(ReadAccountDto), 200)]
        public async Task<ActionResult> GetAccountByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest(new
                {
                    Error = "No Username Provided"
                });
            }

            try
            {
                var account = await _accountService.GetAccountByUsernameAsync(username).ConfigureAwait(false);
                return Ok(account);
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
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
