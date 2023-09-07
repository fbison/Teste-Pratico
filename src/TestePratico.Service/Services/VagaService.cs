using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using System;
using System.Security.Claims;
using TestePratico.Domain.Consts;
using TestePratico.Infra.CrossCutting.Utils;
using TestePratico.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Collections.Generic;

namespace TestePratico.Service.Services
{
    public class VagaService : BaseService<Vaga>, IVagaService
    {
        private readonly IVagaRepository _vagaRepository;

        public VagaService(IVagaRepository VagaRepository) : base(VagaRepository)
        {
            _vagaRepository = VagaRepository;
        }

        public Result<List<Candidato>> ObterCandidatosPorVaga(Guid idVaga)
        {
            try
            {
                return Result<List<Candidato>>.Ok(_vagaRepository.ObterCandidatosPorVaga(idVaga));
            }
            catch (Exception e)
            {
                return Result<List<Candidato>>.Error(Errors.VagasErroObterCandidatosPorVaga);
            }
        }
        public Result<List<Vaga>> ObterVagasPorEmpresa(Guid idEmpresa)
        {
            try
            {
                return Result<List<Vaga>>.Ok(_vagaRepository.ObterVagasPorEmpresa(idEmpresa));
            }
            catch (Exception e)
            {
                return Result<List<Vaga>>.Error(Errors.VagasErroObterVagasPorEmpresa);
            }
        }

    }
}

