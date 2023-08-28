using System;
using TestePratico.Domain.Models;
using TestePratico.Domain.Entities;
using System.Collections.Generic;

namespace TestePratico.Domain.Interfaces
{
    public interface ICandidaturaService: IBaseService<Candidatura>
    {
        public Result DescandidatarAVaga(Guid idUsuario, Guid idVaga);
        public Result<List<Vaga>> obterVagasPorIdUsuario(Guid idUsuario);
        

        }
    }
