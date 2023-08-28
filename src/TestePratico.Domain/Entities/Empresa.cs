using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace TestePratico.Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public List<Vaga> Vagas { get; set; }
    }
}