﻿using TestePratico.Domain.Consts;
using TestePratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePratico.Application.DTOs
{
    public class EditarCandidaturaRequest
    {
        public Guid Id { get; set; }
        public Guid FkIdUsuario { get; set; }
        public Guid FkIdVaga { get; set; }

        public Result Validar()
        {
            if (this.Id == Guid.Empty ||
                this.FkIdVaga == Guid.Empty ||
                this.FkIdUsuario == Guid.Empty  )
            {
                return Result.Error(Errors.DadosEnviadosIncorretamente);
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
