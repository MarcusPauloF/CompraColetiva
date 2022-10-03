using acme.sistemas.compracoletiva.domain.Entity.Security;
using System.Security.Cryptography;

namespace acme.sistemas.compracoletiva.core.Helpers
{
    public class GenarationKeyAuthentication
    {
        public static ChaveCriptofrafia GenarateKey()
        {
            ChaveCriptofrafia chave = new ChaveCriptofrafia();
            RSA rsa = RSA.Create(2048);
            chave.ChavePrivada = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            chave.ChavePublica = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            return chave;
        }

    }
}
