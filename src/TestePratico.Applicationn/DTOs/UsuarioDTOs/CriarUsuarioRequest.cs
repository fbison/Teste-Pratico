using TestePratico.Domain.Consts;
using TestePratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePratico.Application.DTOs
{
    public class CriarUsuarioRequest
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public byte? Tipo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Profissao { get; set; }

        public Result Validar()
        {
            if (this.Tipo == null ||
                String.IsNullOrEmpty(this.Login) ||
                String.IsNullOrEmpty(this.Senha) ||
                String.IsNullOrEmpty(this.Email) ||
                String.IsNullOrEmpty(this.Nome) ||
                String.IsNullOrEmpty(this.CPF) ||
                String.IsNullOrEmpty(this.Profissao) ||
                (this.DataNascimento)== null)
            {
                return Result.Error(Errors.DadosEnviadosIncorretamente);
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
