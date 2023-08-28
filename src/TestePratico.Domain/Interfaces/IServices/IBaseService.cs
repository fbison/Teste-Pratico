using TestePratico.Domain.Entities;
using TestePratico.Domain.Models;
using System;
using System.Collections.Generic;

namespace TestePratico.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public Result Criar(TEntity entity);
        public Result Deletar(Guid id);
        public Result<List<TEntity>> Obter();
        public Result<TEntity> ObterPorId(Guid id);
        public Result Editar(TEntity entity);
        public void Validar(TEntity obj);
    }
}
