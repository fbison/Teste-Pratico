using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestePratico.Domain.Consts;
using System;

namespace TestePratico.UnitTest
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void TestConsts()
        {
            for (byte i = 0; i <= 255; i++)
            {
                if (EnumTipoDados.Validate(i))
                {
                    if (EnumTipoDados.GetName(i) == null)
                    {
                        throw new Exception("Erro ao obter nome ou validar");
                    }
                }
                else
                {
                    if (EnumTipoDados.GetName(i) != null)
                    {
                        throw new Exception("Erro ao obter nome ou validar");
                    }
                }
            }
        }
    }
}
