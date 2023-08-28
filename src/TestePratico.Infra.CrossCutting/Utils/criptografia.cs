using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TestePratico.Infra.CrossCutting.Utils
{
    public class Criptografia
    {
        //Chave Interna
        public string Key { get; set; } = string.Empty;

        private readonly SymmetricAlgorithm _algorithm;

        public Criptografia()
        {
            _algorithm = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };
        }

        public virtual byte[] GetKey()
        {
            string salt = string.Empty;
            // Ajusta o tamanho da chave se necessário e retorna uma chave válida
            if (_algorithm.LegalKeySizes.Length > 0)
            {
                // Tamanho das chaves em bits
                int keySize = Key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Busca o valor máximo da chave
                    Key = Key.Substring(0, maxSize / 8);
                } else if (keySize < maxSize)
                {
                    // Seta um tamanho válido
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        // Preenche a chave com arterisco para corrigir o tamanho
                        Key = Key.PadRight(validSize / 8, '*');
                    }
                }
            }

            var key = new PasswordDeriveBytes(Key, Encoding.ASCII.GetBytes(salt));
            return key.GetBytes(Key.Length);
        }

        public virtual string Criptografar(string key, string texto)
        {
            byte[] plainByte = Encoding.UTF8.GetBytes(texto);

            // Seta a chave privada
            _algorithm.Key = GetKey();
            _algorithm.IV = Convert.FromBase64String(key);

            // Interface de criptografia / Cria objeto de criptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateEncryptor();
            var _memoryStream = new MemoryStream();
            var _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

            // Grava os dados criptografados no MemoryStream
            _cryptoStream.Write(plainByte, 0, plainByte.Length);
            _cryptoStream.FlushFinalBlock();

            // Busca o tamanho dos bytes encriptados
            byte[] cryptoByte = _memoryStream.ToArray();

            // Converte para a base 64 string para uso posterior em um xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));

        }
    }
}
