using AutoMapper;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Consts;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TestePratico.Application.Controllers.v1
{
	[AllowAnonymous]
	[Route("v1/[controller]/[action]")]
	public class LoginController : ApiControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUsuarioService _usuarioService;

		public LoginController(IMapper mapper, IUsuarioService usuarioService)
		{
			_mapper = mapper;
			_usuarioService = usuarioService;

		}

		/// <summary>
		/// Realiza Login do usuário
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("", Name = "Realiza Login do usuário")]
		[Consumes("application/x-www-form-urlencoded")]
		[ProducesResponseType(typeof(LoginResponse),StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ErroResult), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(ErroResult), StatusCodes.Status500InternalServerError)]
		public IActionResult Autenticar([FromForm] LoginRequest request)
		{
			if (request == null) return BadRequest(Result.Error(Errors.RequestInvalido).Notifications);
			var result = _usuarioService.Autenticar(request.Username, request.Password);
			var usuario = _mapper.Map<LoginResponse>(result.Valor);
			return result.IsValid ? Ok(usuario) : BadRequest(result.Notifications);
		}
	}
}
