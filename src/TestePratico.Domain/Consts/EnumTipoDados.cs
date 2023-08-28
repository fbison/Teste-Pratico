using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Domain.Consts
{
    /// <summary>
    /// <para>Representa qual o tipo do dado, na tabela de estrutura de dados
    /// </summary>
    public static class EnumTipoDados
    {
        public const byte Inteiro = 0;
        public const byte PontoFlutuante = 32;
        public const byte Booleano = 64;
        public const byte Texto = 96;
        public const byte Guid = 111;
        public const byte ReferenciaUmParaUm = 128;
        public const byte ReferenciaUmParaMuitos = 160;
        public const byte ReferenciaMuitosParaMuitos = 192;
        public const byte Objeto = 224;

        public static bool Validate(byte value)
        {
            FieldInfo[] fields = typeof(EnumTipoDados).GetFields();
            bool response = false;

            for (int i = 0; i < fields.Length && !response; i++)
                response = fields[i].GetValue(null).Equals(value);

            return response;
        }

        public static string GetName(byte value)
        {
            FieldInfo[] fields = typeof(EnumTipoDados).GetFields();
            string response = null;

            for (int i = 0; i < fields.Length && response == null; i++)
                if (fields[i].GetValue(null).Equals(value))
                    response = fields[i].Name;

            return response;
        }
    }
}
