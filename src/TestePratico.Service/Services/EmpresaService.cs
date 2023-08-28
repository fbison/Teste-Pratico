using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using System;
using System.Security.Claims;
using TestePratico.Domain.Consts;
using TestePratico.Infra.CrossCutting.Utils;
using TestePratico.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TestePratico.Service.Services
{
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        private readonly UserConfig _userConfig;
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository, IOptions<UserConfig> options) : base(EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
            _userConfig = options.Value;
        }

    }
}

