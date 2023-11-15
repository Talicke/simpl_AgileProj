using Api.AgileProj.Business.Dto.TakeParts;
using Api.AgileProj.Business.Mapper.TakeParts;
using Api.AgileProj.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.AgileProj.Business.Services
{
    public class TakePartService
    {
        private readonly ITakePartRepo _takePartRepo;
        private readonly IAccountRepo _accountRepo;
        private readonly IProjectRepo _projectRepo;

        public TakePartService(ITakePartRepo takePartRepo, IAccountRepo accountRepo, IProjectRepo projectRepo)
        {
            _takePartRepo = takePartRepo;
            _accountRepo = accountRepo;
            _projectRepo = projectRepo;
        }

        /// <summary>
        /// Return a list of projectId by AccountId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<List<ReadTakePartDto>> GetTakePartByAccountAsync(int accountId)
        {
            var TakeParts = await _takePartRepo.getTakePartByIdAccount(accountId)
                .ConfigureAwait(false);
            List<ReadTakePartDto> readTakePartDtos = new List<ReadTakePartDto>();

            foreach (var takePart in TakeParts)
            {
                readTakePartDtos.Add(TakePartMapper.TransformEntityToReadTakePartDto(takePart));
            }
            return readTakePartDtos;
        }

        /// <summary>
        /// Associate an Account to a project
        /// </summary>
        /// <param name="takePartDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadTakePartDto> CreateTakePartAsync(CreateTakePartDto takePartDto)
        {
            if(takePartDto == null)
            {
                throw new ArgumentNullException(nameof(takePartDto));
            }

            // Vérify id account is valid
            var account = await _accountRepo.GetAccountByIdAsync(takePartDto.IdAccount)
                .ConfigureAwait(false);

            if(account == null)
            {
                throw new Exception($"Echec de l'assignation, le compte n'existe pas = {takePartDto.IdAccount}");
            }

            //Verify id project is valid
            var project = await _projectRepo.GetProjectByIdAsync(takePartDto.idProject)
                .ConfigureAwait(false);

            if (project == null)
            {
                throw new Exception($"Echec de l'assignation, le projet n'existe pas = {takePartDto.idProject}");
            }

            var takePartToAdd = TakePartMapper.TransformCreateTakePartDtoToEntity(takePartDto);
            var takePartAdded = await _takePartRepo.CreateTakePartAsync(takePartToAdd)
                .ConfigureAwait(false);

            return TakePartMapper.TransformEntityToReadTakePartDto(takePartAdded);
        }

    }
}
