using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace TestePratico.Domain.Entities
{
    public class Candidatura : BaseEntity
    {

        public Guid FkIdUsuario { get; set; }
        public Guid FkIdVaga { get; set; }

        public Usuario Usuario { get; set; }
	    public Vaga Vaga { get; set; }

    }
}