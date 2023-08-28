using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico.Infra.Data.Repository
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        protected new readonly DataDbContext _dataDbContext;

        public EmpresaRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

    }
}
