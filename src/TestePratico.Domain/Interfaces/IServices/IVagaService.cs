using System;
using TestePratico.Domain.Models;
using TestePratico.Domain.Entities;
using System.Collections.Generic;
using TestePratico.Domain.Consts;

namespace TestePratico.Domain.Interfaces
{
    public interface IVagaService: IBaseService<Vaga>
    {
        public Result<List<Candidato>> ObterCandidatosPorVaga(Guid idVaga);
        public Result<List<Vaga>> ObterVagasPorEmpresa(Guid idEmpresa);
    }
}
