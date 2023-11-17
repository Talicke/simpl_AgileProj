using Api.AgileProj.Business.Dto.Accounts;
using Api.AgileProj.Business.Dto.Tasks;
using Api.AgileProj.Business.Mapper.Accounts;
using Api.AgileProj.Business.Services.Contract;
using Api.AgileProj.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ITaskRepo _taskRepo;

        public AccountService(IAccountRepo accountRepo, ITaskRepo taskRepo)
        {
            _accountRepo = accountRepo;
            _taskRepo = taskRepo;
        }

        /// <summary>
        /// Return a list of account
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadAccountDto>> GetAccountAsync()
        {
            var Accounts = await _accountRepo.GetAccountsAsync().ConfigureAwait(false);
            List<ReadAccountDto> readAccountDtos = new List<ReadAccountDto>();

            foreach (var account in Accounts)
            {
                readAccountDtos.Add(AccountMapper
                    .TransformEntityToReadAccountDto(account));
            }
            return readAccountDtos;
        }

        /// <summary>
        /// Return an Account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ReadAccountDto> GetAccountByUsernameAsync(string username)
        {
            var account = await _accountRepo.GetAccountByUsernameAsync(username);
            return AccountMapper.TransformEntityToReadAccountDto(account);
        }

        /// <summary>
        /// Allow login
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public async Task<bool> login(CreateAccountDto accountDto) 
        {
            var account = await _accountRepo.GetAccountByUsernameAsync(accountDto.Username);

            if (account != null) 
            {
                if(account.Password == accountDto.Password) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Create an account if username not exist
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadAccountDto> CreateAccountAsync(CreateAccountDto accountDto)
        {
            if(accountDto == null)
            {
                throw new ArgumentNullException(nameof(accountDto));
            }

            //verify username account doesn't already exist
            var existAccount = await _accountRepo.GetAccountByUsernameAsync(accountDto.Username);

            if (existAccount != null)
            {
                throw new Exception("Nom utilisateur déjà prit");
            }

            var accountToAdd = AccountMapper.TransformCreateDtoToEntity(accountDto);
            var accountAdded = await _accountRepo.CreateAccountAsync(accountToAdd)
                .ConfigureAwait(false);
            return AccountMapper.TransformEntityToReadAccountDto(accountAdded);
        }


    }
}
