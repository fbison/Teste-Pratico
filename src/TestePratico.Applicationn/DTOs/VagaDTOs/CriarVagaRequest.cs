using TestePratico.Domain.Consts;
using TestePratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePratico.Application.DTOs
{
    public class CriarVagaRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float? Salario { get; set; }
        public Guid FkIdEmpresa { get; set; }

        public Result Validar()
        {
            if (this.FkIdEmpresa == Guid.Empty ||
                (this.Titulo != null && String.IsNullOrWhiteSpace(this.Titulo)) ||
                (this.Descricao != null && String.IsNullOrWhiteSpace(this.Descricao)))
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
