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

namespace TestePratico.Service.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly UserConfig _userConfig;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IOptions<UserConfig> options) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _userConfig = options.Value;
        }

        public Result<UsuarioWithToken> Autenticar(string username, string password)
        {
            var user = _usuarioRepository.RecuperarPeloLogin(username);

            if (user == null)
                return Result<UsuarioWithToken>.Error(Errors.UsuarioApplicationUsuarioNaoEncontrado);
            else if (!user.Ativo)
                return Result<UsuarioWithToken>.Error(Errors.UsuarioApplicationUsuarioDesativado);
            else if (user.Senha != new Criptografia().Criptografar(_userConfig.KeySenhaUsuario, password))
                return Result<UsuarioWithToken>.Error(Errors.UsuarioApplicationSenhaInvalida);

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("Id", user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Tipo.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_userConfig.KeyTokenLogin);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var usuarioWithToken = new UsuarioWithToken(user, tokenHandler.WriteToken(token));
            return Result<UsuarioWithToken>.Ok(usuarioWithToken);
        }

        public override Result<Usuario> Criar(Usuario novoUsuario)
        {
            var response = Result<Usuario>.Ok(null);

            // Validar se novo usuário é válido ou se login já está em uso
            var usuario = _usuarioRepository.RecuperarPeloLogin(novoUsuario.Login);
            if (novoUsuario == null || usuario != null)
            {
                response = Result<Usuario>.Error(Errors.UsuarioLoginExiste);
            }
            try
            {
                usuario = new Usuario
                {
                    Id = new Guid(),
                    Email = novoUsuario.Email,
                    Tipo = novoUsuario.Tipo,
                    Ativo = true,
                    Login = novoUsuario.Login,
                    CPF = novoUsuario.CPF,
                    Profissao = novoUsuario.Profissao,
                    DataNascimento = novoUsuario.DataNascimento,
                    Nome= novoUsuario.Nome,
                    Senha = new Criptografia().Criptografar(_userConfig.KeySenhaUsuario, novoUsuario.Senha)
                };

                _usuarioRepository.Inserir(usuario);
            }
            catch (Exception ex)
            {
                response = Result<Usuario>.Error(Errors.GlobalErroDeRepositorio.Key, ex.Message);
            }

            return response;
        }

        public Result<Usuario> Editar(Usuario usuarioEditado, Guid idUsuarioLogado)
        {
            var response = Result<Usuario>.Ok(null);

            // Validar usuário existente
            var usuario = _usuarioRepository.Selecionar(usuarioEditado.Id);
            if (usuario == null)
            {
                response = Result<Usuario>.Error(Errors.RequestInvalido);
            }
            else
            {
                // Validar login do usuário
                var usuarioLogin = _usuarioRepository.RecuperarPeloLogin(usuarioEditado.Login);
                if (usuarioLogin != null && usuarioLogin.Id != usuario.Id)
                {
                    response = Result<Usuario>.Error(Errors.RequestInvalido);
                }
                else if ((!usuarioEditado.Ativo) && (usuarioEditado.Id == idUsuarioLogado))
                {
                    response = Result<Usuario>.Error(Errors.UsuarioAutoDesativando);
                }
                else
                {
                    try
                    {
                        #region Merge "usuario" com "usuarioEditado"
                        usuario.Ativo = usuarioEditado.Ativo;
                        
                        if (usuarioEditado.Email != null)
                            usuario.Email = usuarioEditado.Email;
                        if (EnumTipoUsuario.Validate(usuarioEditado.Tipo.ToString()))
                        {
                            if (usuarioEditado.Tipo.ToString() == EnumTipoUsuario.Externo && usuario.Id == idUsuarioLogado)
                            {
                                return Result<Usuario>.Error(Errors.UsuarioTrocandoPermissao);
                            }
                            usuario.Tipo = usuarioEditado.Tipo;
                        }
                        if (usuarioEditado.Login != null)
                            usuario.Login = usuarioEditado.Login;
                        if (usuarioEditado.Senha != null)
                            usuario.Senha = new Criptografia().Criptografar(_userConfig.KeySenhaUsuario, usuarioEditado.Senha);
                      
                        #endregion

                        _usuarioRepository.Atualizar(usuario);
                    }
                    catch (Exception ex)
                    {
                        response = Result<Usuario>.Error(Errors.GlobalErroDeRepositorio.Key, ex.Message);
                    }
                }
            }

            return response;
        }

        public Result Deletar(Guid id, Guid idUsuarioLogado)
        {
            try
            {
                if (_usuarioRepository.Selecionar(id) == null)
                {
                    return Result.Error(Errors.IdNaoEncontrado);
                }
                if(idUsuarioLogado == id)
                {
                    return Result.Error(Errors.UsuarioAutoDeletando);
                }
                _usuarioRepository.Deletar(id);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Error(Errors.DeletarFalhou);
            }
        }
    }
}

