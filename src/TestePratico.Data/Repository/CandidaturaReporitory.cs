using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico.Infra.Data.Repository
{
    public class CandidaturaRepository : BaseRepository<Candidatura>, ICandidaturaRepository
    {
        protected new readonly DataDbContext _dataDbContext;

        public CandidaturaRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Candidatura pesquisaCandidatura(Guid idUsuario, Guid idVaga)
        {
            return _dataDbContext.Set<Candidatura>().AsNoTracking()
                .Where(x => x.FkIdUsuario == idUsuario &&
                        x.FkIdVaga == idVaga)
                .FirstOrDefault();
        }
        public List<Vaga> obterVagasPorIdUsuario(Guid idUsuario)
        {
            return _dataDbContext.Set<Candidatura>().AsNoTracking()
                .Include(candidatura =>candidatura.Vaga)
                .Where(x => x.FkIdUsuario == idUsuario)
                .Select(x => x.Vaga)
                .ToList();
        }
    }
}
