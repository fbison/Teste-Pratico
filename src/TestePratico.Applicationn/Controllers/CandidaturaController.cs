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
    public class CandidaturaController : ApiControllerBase
    {
        private readonly ICandidaturaService _candidaturaService;
        private readonly IMapper _mapper;

        public CandidaturaController(ICandidaturaService candidaturaService, IMapper mapper)
        {
            _candidaturaService = candidaturaService;
            _mapper = mapper;
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Criar candidatura
        /// </summary>
        /// <response code="200">Sucesso na criação</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpPost("CriarCandidatura")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CriarCandidatura([FromBody] CriarCandidaturaRequest candidatura)
        {
            return Executar(
                () =>
                {
                    #region Validacao
                    var validacao = candidatura.Validar();
                    if (!validacao.IsValid)
                        return validacao;
                    #endregion
                    var entity = _mapper.Map<Candidatura>(candidatura);
                    return _candidaturaService.Criar(entity);
                });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Editar Usuário
        /// </summary>
        /// <response code="200">Sucesso na edição</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpPut("EditarCandidatura")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult EditarCandidatura([FromBody] EditarCandidaturaRequest candidatura)
        {
            return Executar(() =>
            {
                #region Validacao
                var validacao = candidatura.Validar();
                if (!validacao.IsValid)
                    return validacao;
                #endregion
                return _candidaturaService.Editar(_mapper.Map<Candidatura>(candidatura));
            });
        }


        /// <summary>
        /// [Permitida para usuários administradores]] Deletar candidatura
        /// </summary>
        /// <param name="Id">Dados da candidatura a ser deletada</param>
        /// <response code="200">Sucesso na deleção</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpDelete("DeletarCandidatura")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult DeletarCandidatura(Guid id)
        {

            return Executar(() =>
            {
                #region Validacao
                if (id == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                return _candidaturaService.Deletar(id);
            });
        }
        /// <summary>
        /// [Permitida para usuários administradores]] Retorna todos os candidaturas
        /// </summary>
        /// <returns>Retorna todas as candidaturas</returns>        
        /// <response code="200">Retorna todas as candidaturas</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpGet("ObterCandidaturas")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<List<ObterCandidaturaResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult ObterCandidaturas()
        {
            return Executar(() =>
            {
                var result = _candidaturaService.Obter();
                if (result.IsValid)
                {
                    var response = _mapper.Map<List<ObterCandidaturaResponse>>(result.Valor);
                    return Result<List<ObterCandidaturaResponse>>.Ok(response);
                }
                else
                {
                    return Result<ObterCandidaturaResponse>.Error(result.Notifications);
                }
            }
            );
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Obter candidatura específico pelo ID
        /// </summary>
        /// <returns>Retorna todas as candidaturas</returns>        
        /// <param name="Id">Id da candidatura</param>
        /// <response code="200">Retorna a candidatura, solicitada</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Problema de autenticação</response>
        [HttpGet("ObterPorId")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterCandidaturaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPorId(Guid id)
        {
            return Executar(() =>
            {
                #region Validacao
                if (id == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                var result = (_candidaturaService.ObterPorId(id));
                if (result.IsValid)
                {
                    var response = _mapper.Map<ObterCandidaturaResponse>(result.Valor);
                    return Result<ObterCandidaturaResponse>.Ok(response);
                }
                else
                {
                    return Result<ObterCandidaturaResponse>.Error(result.Notifications);
                }
            });
        }
    }
}
