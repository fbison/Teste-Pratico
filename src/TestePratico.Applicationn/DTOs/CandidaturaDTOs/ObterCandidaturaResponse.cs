using System;

namespace TestePratico.Application.DTOs
{
    public class ObterCandidaturaResponse
    {
        public Guid Id { get; set; }
        public Guid FkIdUsuario { get; set; }
        public Guid FkIdVaga { get; set; }
    }
}
