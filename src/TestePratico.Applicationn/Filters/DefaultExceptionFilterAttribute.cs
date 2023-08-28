using TestePratico.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;

namespace TestePratico.Application.Filters
{
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string ERRO_INESPERADO = "Ocorreu um erro inesperado.";
        private readonly string _returnDetailsException;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="returnDetailsException"></param>
        public DefaultExceptionFilterAttribute(string returnDetailsException)
        {
            _returnDetailsException = returnDetailsException;
        }

        /// <summary>
        /// Método executado quando acontecer uma exceção
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var id = context.HttpContext.TraceIdentifier;
            string rota = context.HttpContext.Request.Path;

            Log.Error(context.Exception, "! {rota} - {id} - " + context.Exception.Message, rota, id);

            var returnDetailsException = _returnDetailsException == bool.TrueString;

            var mensagemErro = returnDetailsException ? context.Exception.ToString() : ERRO_INESPERADO;

            context.Result = new ObjectResult(new ErroResult(mensagemErro))
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
