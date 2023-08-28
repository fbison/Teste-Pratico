using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        protected new readonly DataDbContext _dataDbContext;

        public UsuarioRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Usuario RecuperarPeloLogin(string login)
        {
            return _dataDbContext.Set<Usuario>().AsNoTracking().Where(x => x.Login == login).FirstOrDefault();   
        }

    }
}
