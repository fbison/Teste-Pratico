using TestePratico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestePratico.Domain.Interfaces
{
    public interface ICandidaturaRepository: IBaseRepository<Candidatura>
    {
        public Candidatura pesquisaCandidatura(Guid idUsuario, Guid idVaga);
        public List<Vaga> obterVagasPorIdUsuario(Guid idUsuario);

    }
}
