using Api.AgileProj.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository.Contract
{
    public interface IAccountRepo
    {
        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="accountToAdd">account to add</param>
        /// <returns></returns>
        Task<Account> CreateAccountAsync(Account accountToAdd);

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="accountToDelete"></param>
        /// <returns></returns>
        Task<Account> DeleteAccountAsyn(Account accountToDelete);

        /// <summary>
        /// Update an account
        /// </summary>
        /// <param name="accountToUpdate"></param>
        /// <returns></returns>
        Task<Account> UpdateAccountAsyn(Account accountToUpdate);

        /// <summary>
        /// Get a list of account
        /// </summary>
        /// <returns></returns>
        Task<List<Account>> GetAccountsAsync();

        /// <summary>
        /// Get one account by id
        /// </summary>
        /// <param name="accountId">id of account</param>
        /// <returns></returns>
        Task<Account> GetAccountByIdAsync(int accountId);

        /// <summary>
        /// Get an account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Account> GetAccountByUsername(string username);
    }
}
