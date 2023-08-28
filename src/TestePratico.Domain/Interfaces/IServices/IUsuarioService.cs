using System;
using TestePratico.Domain.Models;
using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Interfaces
{
    public interface IUsuarioService: IBaseService<Usuario>
    {
        public Result<UsuarioWithToken> Autenticar(string username, string password);
        public Result<Usuario> Editar(Usuario usuarioEditado, Guid idUsuarioLogado);
        public Result Deletar(Guid id, Guid idUsuarioLogado);

    }
}
