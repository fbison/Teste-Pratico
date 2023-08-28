using System;

namespace TestePratico.Application.DTOs
{
    public class ObterVagaResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float Salario { get; set; }
        public Guid FkIdEmpresa { get; set; }
    }
}
