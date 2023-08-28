using System;

namespace TestePratico.Application.DTOs
{
    public class ObterEmpresaResponse
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
    }
}
