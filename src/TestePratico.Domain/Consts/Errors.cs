using TestePratico.Domain.Models;
namespace TestePratico.Domain.Consts
{
    public static class Errors
    {
        #region Global
        public static readonly Notificacao GlobalErroDeRepositorio = new("Err01", "Erro durante a execução da requisição, tente mais tarde");
        #endregion

        public static readonly Notificacao RequestInvalido = new("Err", "Dados enviados incorretamente");
        public static readonly Notificacao SenhaInvalida = new("Err", "Não tem autorização para acessar essa url");
        public static readonly Notificacao DeletarFalhou = new("Err", "Não Foi possível deletar");
        public static readonly Notificacao EditarFalhou = new("Err", "Não Foi possível editar");
        public static readonly Notificacao CriarFalhou = new("Err", "Não Foi possível criar");
        public static readonly Notificacao IdNaoEncontrado = new("Err", "Esse registro não foi encontrado");
        public static readonly Notificacao ObterPorIdFalhou = new("Err", "Não Foi possível obter pelo Id");
        public static readonly Notificacao ObterTodosFalhou = new("Err", "Não Foi possível obter todos");

        public static readonly Notificacao DadosEnviadosIncorretamente = new("Err11", "Dados enviados incorretamente");
        public static readonly Notificacao ErroInesperado = new("Err11", "Ocorreu um erro inesperado");
        #region Usuario
        public static readonly Notificacao UsuarioLoginExiste = new("Err11", "Esse login não está disponível");
        public static readonly Notificacao UsuarioApplicationUsuarioNaoEncontrado = new("Err11", "Usuário não encontrado");
        public static readonly Notificacao UsuarioApplicationUsuarioReferenciado = new("Err11", "Usuário referenciado em outra tabela");
        public static readonly Notificacao UsuarioApplicationUsuarioDesativado = new("Err12", "Usuário desativado");
        public static readonly Notificacao UsuarioApplicationSenhaInvalida = new("Err13", "Senha inválida");
        public static readonly Notificacao UsuarioApplicationUsuarioInvalido = new("Err2G", "Usuário informado é inválido ou não existe");
        public static readonly Notificacao UsuarioSemLogin = new("Err2G", "Login é obrigatório");
        public static readonly Notificacao UsuarioAutoDesativando = new("Err2G", "O usuário logado não pode se desativar");
        public static readonly Notificacao UsuarioAutoDeletando = new("Err2G", "O usuário logado não pode se deletar");
        public static readonly Notificacao UsuarioTrocandoPermissao = new("Err2G", "O usuário logado não pode trocar sua permissão");

        #endregion


        #region Candidatura
        public static readonly Notificacao CandidaturaVerificacaoDeCandidatura = new("Err11", "Houve um problema ao verificar candidatura");
        public static readonly Notificacao CandidaturaPesquisarCandidatura = new("Err11", "Houve um problema ao pesquisar candidatura");
        public static readonly Notificacao CandidaturaPesquisarVagasCandidatadas = new("Err11", "Houve um problema ao pesquisar as vagas candidatadas");
        public static readonly Notificacao CandidaturaInexistente = new("Err11", "Essa candidatura não existe");
        public static readonly Notificacao CandidaturaExistente = new("Err11", "Essa candidatura já foi realizada");
        #endregion
        #region Candidatura
        public static readonly Notificacao VagasErroObterCandidatosPorVaga = new("Err11", "Houve um problema ao buscar candidatos por vaga");
        public static readonly Notificacao VagasErroObterVagasPorEmpresa = new("Err11", "Houve um problema ao buscar vagas por Empresa");
        #endregion


    }
}