using AutoMapper;
using FluentValidation;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Domain.Models;
using TestePratico.Domain.Consts;

namespace TestePratico.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual Result Criar(TEntity entity)
        {
            try
            {
                _baseRepository.Inserir(entity);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Error(Errors.CriarFalhou);
            }
        }

        public virtual Result Deletar(Guid id)
        {
            try
            {
                if (_baseRepository.Selecionar(id) == null)
                {
                    return Result.Error(Errors.IdNaoEncontrado);
                }
                _baseRepository.Deletar(id);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Error(Errors.DeletarFalhou);
            }
        }

        public virtual Result<List<TEntity>> Obter()
        {
            try
            {
                var entities = _baseRepository.Selecionar();
                return Result<List<TEntity>>.Ok(entities);
            }
            catch (Exception e)
            {
                return Result<List<TEntity>>.Error(Errors.ObterTodosFalhou);
            }
        }

        public virtual Result<TEntity> ObterPorId(Guid id)
        {
            try
            {
                var entity = _baseRepository.Selecionar(id);
                if (entity == null)
                {
                    return Result<TEntity>.Error(Errors.IdNaoEncontrado);
                }
                return Result<TEntity>.Ok(entity);
            }
            catch (Exception)
            {
                return Result<TEntity>.Error(Errors.DeletarFalhou);
            }
        }

        public virtual Result Editar(TEntity entity)
        {
            try
            {
                _baseRepository.Atualizar(entity);
                return Result.Ok();

            }
            catch (Exception)
            {
                return Result.Error(Errors.EditarFalhou);
            }
        }

        public virtual void Validar(TEntity obj)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");
        }
    }
}
