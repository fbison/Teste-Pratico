using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TestePratico.Domain.Models
{
    /// <summary>Result Simples</summary>
    public class Result : Notifiable<Notificacao>
    {
        protected Result() { }
        protected Result(IReadOnlyCollection<Notificacao> notifications) => AddNotifications(notifications);

        /// <summary>Cria resultado de sucesso</summary>
        public static Result Ok() => new();

        /// <summary> Cria resultado sem sucesso </summary>
        public static Result Error(IReadOnlyCollection<Notificacao> notifications) => new(notifications);

        /// <summary>Cria resultado sem sucesso</summary>
        public static Result Error(List<Notificacao> notifications) => new(notifications);

        /// <summary>Cria resultado sem sucesso</summary>
        public static Result Error(Notificacao notifications) => Error(new List<Notificacao> { notifications });
        
        /// <summary>Cria resultado sem sucesso</summary>
        public static Result Error(string codigo, string mensagem) => Error(new Notificacao(codigo, mensagem));

        /// <summary>Cria resultado sem sucesso</summary>
        public static Result Error(Notifiable<Notificacao> notifiable) => new(notifiable.Notifications);
    }

    /// <summary>Result com tipo objeto</summary>
    public class Result<T> : Result
    {
        /// <summary> Objeto do tipo T retornado</summary>
        public T Valor { get; }

        private Result(T obj) => Valor = obj;
        protected Result(IReadOnlyCollection<Notificacao> notificacoes) => AddNotifications(notificacoes);

        public static Result<T> Ok(T obj) => new Result<T>(obj);

        /// <summary>Cria resultado sem sucesso</summary>
        public static new Result<T> Error(IReadOnlyCollection<Notificacao> notificacoes) => new(notificacoes);

        /// <summary>Cria resultado sem sucesso</summary>
        public static new Result<T> Error(List<Notificacao> notificacaoes) => new(notificacaoes);

        /// <summary>Cria resultado sem sucesso</summary>
        public static new Result<T> Error(Notificacao notificacao) => Error(new List<Notificacao> { notificacao });

        /// <summary>Cria resultado sem sucesso</summary>
        public static new Result<T> Error(string codigo, string mensagem) => Error(new Notificacao(codigo, mensagem));

        /// <summary>Cria resultado sem sucesso</summary>
        public static new Result<T> Error(Notifiable<Notificacao> notifiable) => new(notifiable.Notifications);
    }
}
