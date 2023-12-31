﻿using Api.AgileProj.Business.Dto.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services.Contract
{
    public interface IAccountService
    {
        /// <summary>
        /// Return a list of account
        /// </summary>
        /// <returns></returns>
        Task<List<ReadAccountDto>> GetAccountAsync();


        /// <summary>
        /// Return an Account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<ReadAccountDto> GetAccountByUsernameAsync(string username);

        /// <summary>
        /// Create an account if username not exist
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadAccountDto> CreateAccountAsync(CreateAccountDto accountDto);

        /// <summary>
        /// Allow login
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        Task<bool> login(CreateAccountDto accountDto);
    }
}
