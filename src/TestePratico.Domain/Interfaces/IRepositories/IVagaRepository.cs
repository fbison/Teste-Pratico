using TestePratico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestePratico.Domain.Models;

namespace TestePratico.Domain.Interfaces
{
    public interface IVagaRepository: IBaseRepository<Vaga>
    {
        public List<Candidato> ObterCandidatosPorVaga(Guid idVaga);

        public List<Vaga> ObterVagasPorEmpresa(Guid idEmpresa);
    }
}
