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
    public class UsuarioController : ApiControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// [Não realiza autenticação] Criar usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("CriarUsuario")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CriarUsuario([FromBody] CriarUsuarioRequest usuario)
        {
            return Executar(
                () =>
                {
                    #region Validacao
                    var validacao = usuario.Validar();
                    if (!validacao.IsValid)
                        return validacao;
                    #endregion
                    var entity = _mapper.Map<Usuario>(usuario);
                    return _usuarioService.Criar(entity);
                });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Editar Usuário
        /// </summary>
        [HttpPut("EditarUsuario")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult EditarUsuario([FromBody] EditarUsuarioRequest usuario)
        {
            return Executar(() =>
            {
                #region Validacao
                var validacao = usuario.Validar();
                if (!validacao.IsValid)
                    return validacao;
                #endregion
                return _usuarioService.Editar(_mapper.Map<Usuario>(usuario), IdUsuario);
            });
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Deletar usuário
        /// </summary>
        [HttpDelete("DeletarUsuario")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult DeletarUsuario(Guid id)
        {

            return Executar(() =>
            {
                #region Validacao
                if (id == Guid.Empty)
                    return Result.Error(Errors.DadosEnviadosIncorretamente);
                #endregion
                return _usuarioService.Deletar(id, IdUsuario);
            });
        }
        /// <summary>
        /// [Permitida para usuários administradores]] Retorna todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterUsuarios")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<List<ObterUsuarioResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]

        public IActionResult ObterUsuarios()
        {
            return Executar(() =>
            {
                var result = _usuarioService.Obter();
                if (result.IsValid)
                {
                    var response = _mapper.Map<List<ObterUsuarioResponse>>(result.Valor);
                    return Result<List<ObterUsuarioResponse>>.Ok(response);
                }
                else
                {
                    return Result<ObterUsuarioResponse>.Error(result.Notifications);
                }
            }
            );
        }

        /// <summary>
        /// Retorna os dados do usuário Logado
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterDadosUsuarioLogado")]
        [Authorize]
        [ProducesResponseType(typeof(Result<ObterDadosUsuarioLogado>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterDadosUsuarioLogado()
        {
            return Executar(() =>
            {
                var result = _usuarioService.ObterPorId(IdUsuario);
                if (result.IsValid)
                {
                    var response = _mapper.Map<ObterDadosUsuarioLogado>(result.Valor);
                    return Result<ObterDadosUsuarioLogado>.Ok(response);
                }
                else
                {
                    return Result<ObterUsuarioResponse>.Error(result.Notifications);
                }
            }
            );
        }

        /// <summary>
        /// [Permitida para usuários administradores]] Obter usuário específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterPorId")]
        [Authorize(Roles = EnumTipoUsuario.Administrador)]
        [ProducesResponseType(typeof(Result<ObterUsuarioResponse>), StatusCodes.Status200OK)]
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
                var result = (_usuarioService.ObterPorId(id));
                if (result.IsValid)
                {
                    var response = _mapper.Map<ObterUsuarioResponse>(result.Valor);
                    return Result<ObterUsuarioResponse>.Ok(response);
                }
                else
                {
                    return Result<ObterUsuarioResponse>.Error(result.Notifications);
                }
            });
        }
    }
}
