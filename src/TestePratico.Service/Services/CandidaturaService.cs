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
    public class CandidaturaService : BaseService<Candidatura>, ICandidaturaService
    {
        private readonly UserConfig _userConfig;
        private readonly ICandidaturaRepository _candidaturaRepository;

        public CandidaturaService(ICandidaturaRepository CandidaturaRepository, IOptions<UserConfig> options) : base(CandidaturaRepository)
        {
            _candidaturaRepository = CandidaturaRepository;
            _userConfig = options.Value;
        }
        public override Result Criar(Candidatura candidatura) {
            try
            {
                if(CandidaturaExiste(candidatura.FkIdUsuario, candidatura.FkIdVaga))
                {
                    return Result.Error(Errors.CandidaturaExistente);
                }
                _candidaturaRepository.Inserir(candidatura);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Error(Errors.CriarFalhou);
            }
        }

        public Result DescandidatarAVaga(Guid idUsuario, Guid idVaga)
        {
            Result<Candidatura> candidatura = PesquisaCandidatura(idUsuario, idVaga);
            if (!candidatura.IsValid) {
                return Result.Error(candidatura.Notifications);
            }
            if(candidatura.Valor == default(Candidatura))
            {
                return Result.Error(Errors.CandidaturaInexistente);
            }
            return Deletar(candidatura.Valor.Id);
            
        }

        public bool CandidaturaExiste(Guid idUsuario, Guid idVaga) {
            try {
                Result<Candidatura> candidatura = PesquisaCandidatura(idUsuario, idVaga);
                if (candidatura.IsValid) return candidatura.Valor != default(Candidatura);
            }catch(Exception)
            {
                throw new DefaultException(Errors.CandidaturaVerificacaoDeCandidatura.Message);
            }
            throw new DefaultException(Errors.CandidaturaVerificacaoDeCandidatura.Message);
        }
        public Result<Candidatura> PesquisaCandidatura(Guid idUsuario, Guid idVaga) {
            try
            {
                return Result<Candidatura>.Ok(_candidaturaRepository.pesquisaCandidatura(idUsuario, idVaga));
            }
            catch (Exception e)
            {
                return Result<Candidatura>.Error(Errors.CandidaturaPesquisarCandidatura);
            }
        }
        public Result<List<Vaga>> obterVagasPorIdUsuario(Guid idUsuario){
            try
            {
                return Result<List<Vaga>>.Ok(_candidaturaRepository.obterVagasPorIdUsuario(idUsuario));
            }
            catch (Exception e)
            {
                return Result<List<Vaga>>.Error(Errors.CandidaturaPesquisarVagasCandidatadas);
            }
        }

    }
}

