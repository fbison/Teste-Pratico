using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace TestePratico.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
	    public byte Tipo { get; set; }
	    public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Profissao { get; set; }
        public List<Candidatura> Candidaturas { get; set; }

    }
}