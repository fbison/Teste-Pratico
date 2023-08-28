namespace TestePratico.Application.DTOs
{
    public class Erro
    {
        public Erro(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public Erro(string descricao)
        {
            Descricao = descricao;
        }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
