using acme.sistemas.compracoletiva.core.Helpers;

namespace acme.sistemas.compracoletiva.domain.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var keys = GenarationKeyAuthentication.GenarateKey();
            CriptografiaAssincrona criptografiaAssincrona = new CriptografiaAssincrona();
            var criptografado = criptografiaAssincrona.Criptografar(keys.ChavePublica, "123@Mudar");
            var descriptografado = criptografiaAssincrona.Descriptofrafar(keys.ChavePrivada, criptografado);

            Assert.Equal("123@Mudar", descriptografado);
        }
    }
}