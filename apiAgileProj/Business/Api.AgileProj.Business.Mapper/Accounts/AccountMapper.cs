using Api.AgileProj.Business.Dto.Accounts;
using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Mapper.Accounts
{
    public static class AccountMapper
    {
        /// <summary>
        /// Transform a Dto CreateAccount to Account Entity
        /// </summary>
        /// <param name="createAccount"></param>
        /// <returns></returns>
        public static Account TransformCreateDtoToEntity(CreateAccountDto createAccount)
        {
            return new Account()
            {
                Username = createAccount.Username,
                Password = createAccount.Password
            };
        }

        public static ReadAccountDto TransformEntityToReadAccountDto(Account account)
        {
            return new ReadAccountDto()
            {
                Id = account.Id,
                Username = account.Username,
                Password = account.Password,
                Tasks = account.Tasks
            };
        }
    }
}
