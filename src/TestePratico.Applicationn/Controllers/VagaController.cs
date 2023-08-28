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
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace TestePratico.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ApiControllerBase
    {
        private readonly IVagaService _vagaService;
        private readonly IMapper _mapper;

        public VagaController(IVagaService vagaService, IMapper mapper)
        {
            _vagaService = vagaService;
            _mapper = mapper;
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Criar vaga
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
        [HttpPost("CriarVaga")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CriarVaga([FromBody] CriarVagaRequest vaga)
        {
            return Executar(
                () =>
                {
                    #region Validacao
                    var validacao = vaga.Validar();
                    if (!validacao.IsValid)
                        return validacao;
                    #endregion
                    var entity = _mapper.Map<Vaga>(vaga);
                    return _vagaService.Criar(entity);
                });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Editar Usuário
        /// </summary>
        [HttpPut("EditarVaga")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult EditarVaga([FromBody] EditarVagaRequest vaga)
        {
            return Executar(() =>
            {
                #region Validacao
                var validacao = vaga.Validar();
                if (!validacao.IsValid)
                    return validacao;
                #endregion
                return _vagaService.Editar(_mapper.Map<Vaga>(vaga));
            });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Deletar vaga
        /// </summary>
        [HttpDelete("DeletarVaga")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult DeletarVaga(Guid id)
        {

            return Executar(() =>
            {
                #region Validacao
                if (id == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                return _vagaService.Deletar(id);
            });
        }
        /// <summary>
        /// [Permitida para todos os usuários] Retorna todos os vagas
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterVagas")]
        [Authorize]
        [ProducesResponseType(typeof(Result<List<ObterVagaResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult ObterVagas()
        {
            return Executar(() =>
            {
                var result = _vagaService.Obter();
                if (result.IsValid)
                {
                    var response = _mapper.Map<List<ObterVagaResponse>>(result.Valor);
                    return Result<List<ObterVagaResponse>>.Ok(response);
                }
                else
                {
                    return Result<ObterVagaResponse>.Error(result.Notifications);
                }
            }
            );
        }

        /// <summary>
        /// [Permitida para usuários administradores] Obter vaga específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterPorId")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterVagaResponse>), StatusCodes.Status200OK)]
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
                var result = (_vagaService.ObterPorId(id));
                if (result.IsValid)
                {
                    var response = _mapper.Map<ObterVagaResponse>(result.Valor);
                    return Result<ObterVagaResponse>.Ok(response);
                }
                else
                {
                    return Result<ObterVagaResponse>.Error(result.Notifications);
                }
            });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Obter vaga específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterPorIdEmpresa")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterVagaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPorIdEmpresa(Guid idEmpresa)
        {
            return Executar(() =>
            {
                #region Validacao
                if (idEmpresa == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                var result = (_vagaService.ObterVagasPorEmpresa(idEmpresa));
                if (result.IsValid)
                {
                    var response = _mapper.Map<List<ObterVagaResponse>>(result.Valor);
                    return Result<List<ObterVagaResponse>>.Ok(response);
                }
                else
                {
                    return Result<List<ObterVagaResponse>>.Error(result.Notifications);
                }
            });
        }
        
        /// <summary>
        /// [Permitida para usuários administradores]] Obter vaga específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterCandidatosDeVaga")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterVagaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterCandidatosDeVaga(Guid idVaga)
        {
            return Executar(() =>
            {
                #region Validacao
                if (idVaga == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                var result = (_vagaService.ObterCandidatosPorVaga(idVaga));
                if (result.IsValid)
                {
                    return Result<List<Candidato>>.Ok(result.Valor);
                }
                else
                {
                    return Result<List<Candidato>>.Error(result.Notifications);
                }
            });
        }
    }
}
