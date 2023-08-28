using TestePratico.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TestePratico.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Inserir(TEntity obj);
        TEntity InserirERetornar(TEntity obj);

        public TEntity AtualizarERetornar(TEntity obj);

        void Atualizar(TEntity obj);

        void Deletar(Guid id);
        void Deletar(List<TEntity> listEntity);
        public void RemoveContext();

        List<TEntity> Selecionar();

        TEntity Selecionar(Guid id);
    }
}
