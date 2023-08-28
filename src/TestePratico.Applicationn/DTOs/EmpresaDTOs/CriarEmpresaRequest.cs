using TestePratico.Domain.Consts;
using TestePratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePratico.Application.DTOs
{
    public class CriarEmpresaRequest
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }

        public Result Validar()
        {
            if ((this.Cnpj != null && String.IsNullOrWhiteSpace(this.Cnpj)) ||
                (this.Nome != null && String.IsNullOrWhiteSpace(this.Nome)))
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
