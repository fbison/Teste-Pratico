using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace TestePratico.Domain.Entities
{
    public class Vaga : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float Salario { get; set; }
	    public Guid FkIdEmpresa { get; set; }
	    public Empresa Empresa { get; set; }
        public List<Candidatura> Candidaturas { get; set; }
    }
}