using TestePratico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestePratico.Domain.Interfaces
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        public Usuario RecuperarPeloLogin(string login);
    }
}
