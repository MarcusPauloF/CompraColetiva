using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace acme.sistemas.compracoletiva.fakeintegration.api.Modelo
{
    public class PayloadCombateFraude
    {
        public string ISS { get => "62b6056f78a798000926d1e1"; }
        public DateTime Ext { get=>DateTime.Now.AddMinutes(15.2); }
        public string PersonId { get => "12486468609"; }
    }

    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }

    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials = new SigningCredentials(Key, "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyI2MmI2MDU2Zjc4YTc5ODAwMDkyNmQxZTEiLCI2MmI2MDU2Zjc4YTc5ODAwMDkyNmQxZTEiXSwianRpIjoiMDRlZmJlMjYyMTI0NDdmYmIxNDI1ZmNiN2U0ZmQxNzYiLCJuYmYiOjE2NTcxMTEzMTYsImV4cCI6MTY1NzExNDExNiwiaWF0IjoxNjU3MTExMzIxLCJpc3MiOiI2MmI2MDU2Zjc4YTc5ODAwMDkyNmQxZTEiLCJhdWQiOiJBdWRpZW5jZSJ9.oP7PhrijiTXObuT7MjdAO4jB882U2P4BT8OqUez_xT2uw-3RkgL1fAfzONGyTutOTMnfsAFLCP1j7oldRmAnRd1FskgUlEuaaGCpsR91ixAMFgeQvj2B9KsPs7Bt1Zc0IkQo63k6N0N9nRBj2LetIGIHMm4bge6ov3NtHlTzNwav_ShMERTbZtjaU_qY6iFGeGC-60Q7Y-3_4IruUp7FnmNuI2_OQfxpUEFgKiniJFR9WefoanZpVF8O3tJEWK7fk9VgxpmS9GR9d5jfJWMAtrHzIJYrhIeVCKeVoJs8YwuZpQ9XbRI6o_f89tsqOaEEnh91YfKQXy8XbwqTQDsE1Q");
        }
    }
}
