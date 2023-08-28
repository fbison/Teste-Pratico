using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestePratico.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataDbContext _dataDbContext;

        public BaseRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public void Inserir(TEntity obj)
        {
            _dataDbContext.Set<TEntity>().Add(obj);
            _dataDbContext.SaveChanges();
        }
        

        public void RemoveContext()
        {
            _dataDbContext.ChangeTracker.Clear();
        }

        public TEntity InserirERetornar(TEntity obj)
        {
            _dataDbContext.Set<TEntity>().Add(obj) ;
            _dataDbContext.SaveChanges();
            return Selecionar(obj.Id);
        }
        public TEntity AtualizarERetornar(TEntity obj)
        {
            _dataDbContext.Entry(obj).State = EntityState.Modified;
            _dataDbContext.SaveChanges();
            return Selecionar(obj.Id);
        }
        public void Atualizar(TEntity obj)
        {
            _dataDbContext.Entry(obj).State = EntityState.Modified;
            _dataDbContext.SaveChanges();
        }
        

        public virtual void Deletar(Guid id) {
            
                var entity = Selecionar(id);
                _dataDbContext.Set<TEntity>().Remove(entity);
                _dataDbContext.SaveChanges();
            
        }
        public virtual void Deletar(List<TEntity> listEntity) {
            
                _dataDbContext.Set<TEntity>().RemoveRange(listEntity);
                _dataDbContext.SaveChanges();
            
        }

        public virtual List<TEntity> Selecionar() =>
            _dataDbContext.Set<TEntity>().AsNoTracking().ToList();

        public virtual TEntity Selecionar(Guid id) =>
            _dataDbContext.Set<TEntity>().AsNoTracking().Where(x=> x.Id == id).FirstOrDefault();

    }
}
