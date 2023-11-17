using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity.Model;
using Api.AgileProj.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Data.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly IAgileProjDBContext _dBContext;

        public AccountRepo (IAgileProjDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="accountToAdd">account to add</param>
        /// <returns></returns>
        public async Task<Account> CreateAccountAsync(Account accountToAdd)
        {
            var elementAdded = await _dBContext.Accounts.AddAsync(accountToAdd).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="accountToDelete"></param>
        /// <returns></returns>
        public async Task<Account> DeleteAccountAsyn(Account accountToDelete)
        {
            var elementDeleted = _dBContext.Accounts.Remove(accountToDelete);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Update an account
        /// </summary>
        /// <param name="accountToUpdate"></param>
        /// <returns></returns>
        public async Task<Account> UpdateAccountAsyn(Account accountToUpdate)
        {
            var elementUpdated = _dBContext.Accounts.Update(accountToUpdate);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Get a list of account
        /// </summary>
        /// <returns></returns>
        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _dBContext.Accounts.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Get one account by id
        /// </summary>
        /// <param name="accountId">id of account</param>
        /// <returns></returns>
        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _dBContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId)
                   .ConfigureAwait(false);
        }

        /// <summary>
        /// Get an account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _dBContext.Accounts
                .FirstOrDefaultAsync(x => x.Username == username)
                .ConfigureAwait(false);
        }

        /*
        /// <summary>
        /// Get an account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _dBContext.Accounts.FirstOrDefaultAsync(x => x.Username == username)
                .ConfigureAwait(false);
        }
        */
    }
}
