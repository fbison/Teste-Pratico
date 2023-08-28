using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Domain.Consts
{
    /// <summary>
    /// <para>Representa a tabela Funcao do banco de dados e todos os seus registros como atributos com seus valores iguais aos seus respectivos Ids</para>
    /// <para>É utilizado para definir autorizações de uso de endpoints</para>
    /// </summary>
    public static class EnumTipoUsuario
    {
        public const string Administrador = "1";
        public const string Externo = "2";

        public static bool Validate(string value)
        {
            FieldInfo[] fields = typeof(EnumTipoUsuario).GetFields();
            bool response = false;

            for (int i = 0; i < fields.Length && !response; i++)
                response = fields[i].GetValue(null).Equals(value);

            return response;
        }
    }
}
