using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Helper.Cryptography
{
    public static class AsymmetricEncryption
    {
        private const bool _optimalAsymmetricEncryptionPadding = false;

        public static void GenerateKeys(int keySize, out string publicKey, out string publicAndPrivateKey)
        {
            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                publicKey = provider.ToXmlString(false);
                publicAndPrivateKey = provider.ToXmlString(true);
            }
        }

        public static string EncryptText(string text, string publicKeyXml)
        {
            var encrypted = Encrypt(Encoding.UTF8.GetBytes(text), publicKeyXml);
            return Convert.ToBase64String(encrypted);
        }

        public static byte[] Encrypt(byte[] data, string publicKeyXml)
        {
            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            if (String.IsNullOrEmpty(publicKeyXml)) throw new ArgumentException("Key is null or empty", "publicKeyXml");

            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        public static string DecryptText(string text, string publicAndPrivateKeyXml)
        {
            var decrypted = Decrypt(Convert.FromBase64String(text), publicAndPrivateKeyXml);
            return Encoding.UTF8.GetString(decrypted);
        }

        public static byte[] Decrypt(byte[] data, string publicAndPrivateKeyXml)
        {
            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            if (String.IsNullOrEmpty(publicAndPrivateKeyXml)) throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        public static byte[] Sign(byte[] data, string publicAndPrivateKeyXml)
        {
            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            if (String.IsNullOrEmpty(publicAndPrivateKeyXml)) throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.SignData(data, CryptoConfig.MapNameToOID("SHA1"));
            }
        }

        public static string SignText(string text, string publicAndPrivateKeyXml)
        {
            var sig = Sign(Encoding.UTF8.GetBytes(text), publicAndPrivateKeyXml);
            return Convert.ToBase64String(sig);
        }

        public static bool VerifySig(byte[] data, byte[] sig, string publicKeyXml)
        {
            if (data == null || data.Length == 0) 
                throw new ArgumentException("Data are empty", "data");
            if (String.IsNullOrEmpty(publicKeyXml)) 
                throw new ArgumentException("Key is null or empty", "publicKeyXml");

            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicKeyXml);
                return provider.VerifyData(data, CryptoConfig.MapNameToOID("SHA1"), sig);
            }
        }

        public static bool VerifySignedText(string text, string sig, string publicAndPrivateKeyXml)
        {
            return VerifySig(Encoding.UTF8.GetBytes(text), Convert.FromBase64String(sig), publicAndPrivateKeyXml);
        }

    }
}
