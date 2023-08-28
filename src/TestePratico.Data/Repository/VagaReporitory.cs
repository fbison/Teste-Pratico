using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestePratico.Domain.Models;

namespace TestePratico.Infra.Data.Repository
{
    public class VagaRepository : BaseRepository<Vaga>, IVagaRepository
    {
        protected new readonly DataDbContext _dataDbContext;

        public VagaRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        //A transformação para o model candidato
        //busca impedir que a senha do usuário seja enviada para outra camada
        public List<Candidato> ObterCandidatosPorVaga(Guid idVaga) {

            return _dataDbContext.Set<Candidatura>()
                    .Include(candidatura=> candidatura.Usuario)
                    .Where(candidatura => candidatura.FkIdVaga == idVaga)
                    .Select(candidatura => new Candidato {
                        Email = candidatura.Usuario.Email,
                        Login = candidatura.Usuario.Login,
                        Nome = candidatura.Usuario.Nome,
                        CPF = candidatura.Usuario.CPF,
                        DataNascimento = candidatura.Usuario.DataNascimento,
                        Profissao  =      candidatura.Usuario.Profissao
                    })
                    .ToList();
        }

        public List<Vaga> ObterVagasPorEmpresa(Guid idEmpresa) {

            return _dataDbContext.Set<Vaga>()
                    .Where(vaga => vaga.FkIdEmpresa == idEmpresa)
                    .ToList(); ;
        }
    }
}
