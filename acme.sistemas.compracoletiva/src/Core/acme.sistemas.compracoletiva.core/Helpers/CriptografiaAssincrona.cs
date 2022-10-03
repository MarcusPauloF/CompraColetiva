using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Helpers
{
    public class CriptografiaAssincrona
    {
        public RSA GetRSA(string publicKey)
        {
            ReadOnlySpan<byte> str = new ReadOnlySpan<byte>(Convert.FromBase64String(publicKey));
            RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(str, out _);
            return rsa;
        }

        public string Criptografar(string publicKey, string valor)
        {
            ReadOnlySpan<byte> str = new ReadOnlySpan<byte>(Convert.FromBase64String(publicKey));
            RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(str, out _);

            byte[] dadodEncriptadoByte = rsa.Encrypt(Encoding.Default.GetBytes(valor), RSAEncryptionPadding.OaepSHA512);

            string dadodEncriptado = Convert.ToBase64String(dadodEncriptadoByte);
            
            return dadodEncriptado;
        }
        public string Descriptofrafar(string privateKey,string valorDescriptografar)
        {
            ReadOnlySpan<byte> str = new ReadOnlySpan<byte>(Convert.FromBase64String(privateKey));

            RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(str, out _);

            var descriptografia = rsa.Decrypt(Convert.FromBase64String(valorDescriptografar), RSAEncryptionPadding.OaepSHA512);
            
            return Encoding.Default.GetString(descriptografia);
        }
    }
}
