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
    public class EmpresaController : ApiControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, IMapper mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Criar empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost("CriarEmpresa")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CriarEmpresa([FromBody] CriarEmpresaRequest empresa)
        {
            return Executar(
                () =>
                {
                    #region Validacao
                    var validacao = empresa.Validar();
                    if (!validacao.IsValid)
                        return validacao;
                    #endregion
                    var entity = _mapper.Map<Empresa>(empresa);
                    return _empresaService.Criar(entity);
                });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Editar Usuário
        /// </summary>
        [HttpPut("EditarEmpresa")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult EditarEmpresa([FromBody] EditarEmpresaRequest empresa)
        {
            return Executar(() =>
            {
                #region Validacao
                var validacao = empresa.Validar();
                if (!validacao.IsValid)
                    return validacao;
                #endregion
                return _empresaService.Editar(_mapper.Map<Empresa>(empresa));
            });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Deletar empresa
        /// </summary>
        [HttpDelete("DeletarEmpresa")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult DeletarEmpresa(Guid id)
        {

            return Executar(() =>
            {
                #region Validacao
                if (id == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                return _empresaService.Deletar(id);
            });
        }
        /// <summary>
        /// [Permitida para usuários administradores]] Retorna todos os empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterEmpresas")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<List<ObterEmpresaResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult ObterEmpresas()
        {
            return Executar(() =>
            {
                var result = _empresaService.Obter();
                if (result.IsValid)
                {
                    var response = _mapper.Map<List<ObterEmpresaResponse>>(result.Valor);
                    return Result<List<ObterEmpresaResponse>>.Ok(response);
                }
                else
                {
                    return Result<ObterEmpresaResponse>.Error(result.Notifications);
                }
            }
            );
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Obter empresa específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterPorId")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterEmpresaResponse>), StatusCodes.Status200OK)]
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
                var result = (_empresaService.ObterPorId(id));
                if (result.IsValid)
                {
                    var response = _mapper.Map<ObterEmpresaResponse>(result.Valor);
                    return Result<ObterEmpresaResponse>.Ok(response);
                }
                else
                {
                    return Result<ObterEmpresaResponse>.Error(result.Notifications);
                }
            });
        }
    }
}
