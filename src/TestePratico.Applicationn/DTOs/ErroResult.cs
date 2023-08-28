using System.Collections.Generic;
using System.Linq;

namespace TestePratico.Application.DTOs
{
    /// <summary>
    /// Modelo de resultado para erros
    /// </summary>
    public class ErroResult
    {
        public ErroResult(string erro)
        {
            Erros = new List<Erro> { new(erro) };
        }

        public ErroResult(Erro erro)
        {
            Erros = new List<Erro> { erro };
        }

        public ErroResult(List<string> erros)
        {
            Erros = erros.Select(e => new Erro(e)).ToList();
        }
        
        public ErroResult(List<Erro> erros)
        {
            Erros = erros;
        }

        /// <summary>
        /// Lista com a descrição do erro
        /// </summary>
        public List<Erro> Erros { get; }
    }
}
