using AutoMapper;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Consts;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TestePratico.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaCandidatoController : ApiControllerBase
    {
        private readonly ICandidaturaService _candidaturaService;
        private readonly IMapper _mapper;

        public AreaCandidatoController(ICandidaturaService candidaturaService, IMapper mapper)
        {
            _candidaturaService = candidaturaService;
            _mapper = mapper;
        }

        /// <summary>
        /// [Permitida para usuários externos] Realizar Candidatura do usuário logado
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">Sucesso na candidatura</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpPost("CandidatarUsuarioLogado")]
        [Authorize(Roles = EnumTipoUsuario.Externo)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CandidatarUsuarioLogado(Guid idVaga)
        {
            return Executar(
                () =>
                {
                    #region Validacao
                    if (idVaga == Guid.Empty)
                        return Result.Error(Errors.DadosEnviadosIncorretamente);
                    #endregion

                    return _candidaturaService.Criar(new Candidatura{
                        Id= new Guid(),
                        FkIdUsuario=IdUsuario, 
                        FkIdVaga = idVaga,
                        Usuario= null
                    });
                });
        }
        /// <summary>
        /// [Permitida para usuários externos] Realizar Candidatura do usuário logado
        /// </summary>
        /// <param name="Id">Id da vaga para se candidatar</param>
        /// <response code="200">Sucesso na candidatura</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpGet("ObterVagasCandidatadas")]
        [Authorize(Roles = EnumTipoUsuario.Externo)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterVagasCandidatadas()
        {
            return Executar(
                () =>
                {
                    return _candidaturaService.obterVagasPorIdUsuario(IdUsuario);
                });
        }

        /// <summary>
        /// [Permitida para usuários externos] Descandidatar o usuário logado a uma vaga que ele se candidatou previamente
        /// </summary>
        /// <param name="Id">Id da vaga para se descandidatar</param>
        /// <response code="200">Sucesso na descandidatação</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpDelete("DescandidatarAVaga")]
        [Authorize(Roles = EnumTipoUsuario.Externo)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult DescandidatarAVaga(Guid idVaga)
        {

            return Executar(() =>
            {
                #region Validacao
                if (idVaga == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                return _candidaturaService.DescandidatarAVaga(IdUsuario, idVaga);
            });
        }

    }
}
