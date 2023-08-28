using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Flunt.Notifications;
using TestePratico.Application.DTOs;
using System.Security.Claims;
using System;
using TestePratico.Domain.Models;

namespace TestePratico.Application.Controllers
{
    /// <summary>
    /// Classe base para as controllers da aplicação
    /// </summary>

    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Erro 400
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        protected IActionResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            var erros = notifications.Select(n => new Erro(n.Key, n.Message)).ToList();
            return new BadRequestObjectResult(new ErroResult(erros));
        }

        /// <summary>
        /// ID do usuário autenticado
        /// </summary>
        /// <returns></returns>
        protected Guid IdUsuario => ObterIdDoUsuario();
        private Guid ObterIdDoUsuario()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claims = identity.Claims;
                var id = claims.FirstOrDefault(c => c.Type.ToLower() == "id")?.Value;

                return Guid.Parse(id);
            }
            return Guid.Parse(null);
        }

        protected IActionResult Executar(Func<Result<List<object>>> func)
        {
            try
            {
                var result = func();
                return result.IsValid ? Ok(result) : BadRequest(result.Notifications); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        protected IActionResult Executar(Func<Result<object>> func)
        {
            try
            {
                var result = func();
                return result.IsValid ? Ok(result) : BadRequest(result.Notifications); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        protected IActionResult Executar(Func<Result> func)
        {
            try
            {
                var result = func();
                return result.IsValid ? Ok(result) : BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
