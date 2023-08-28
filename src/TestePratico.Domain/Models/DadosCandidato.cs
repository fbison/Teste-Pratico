using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace TestePratico.Domain.Models
{
    public class Candidato
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Profissao { get; set; }

    }
}