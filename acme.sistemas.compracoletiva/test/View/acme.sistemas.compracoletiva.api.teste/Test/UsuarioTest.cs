using acme.sistemas.compracoletiva.api.teste.Fixture;
using acme.sistemas.compracoletiva.core.Dtos.Security;
using acme.sistemas.compracoletiva.core.Dtos.Users;
using acme.sistemas.compracoletiva.core.Enuns;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace acme.sistemas.compracoletiva.api.teste.Test
{
    [Collection(nameof(IntegrationApiTesteFixtureCollection))]
    public class UsuarioTest
    {
        private readonly IntegrationTesteFixture _integrationTesteFixture;
        public UsuarioTest(IntegrationTesteFixture integrationTesteFixture)
        {
            _integrationTesteFixture = integrationTesteFixture;
        }

        [Fact(DisplayName = "Cadastro de Usuario")]
        [Trait("Usuario", "Integração Usuario")]
        public async Task Usuario_RealizaCadastro_DeveExecutarComSucesso()
        {
            //Arrange
            var claim = new List<ClaimDto>()
                {
                    new ClaimDto() { Nome = "Usuario", Valor = "All" },
                    new ClaimDto() { Nome = "Compra", Valor = "All" },
                    new ClaimDto() { Nome = "Produto", Valor = "All" },
                    new ClaimDto() { Nome = "Email", Valor = "All" }
                };
            var pessoa = new RegistroUsuarioDto()
            {

                ConfirmacaoSenha = "123@Mudar",
                Email = "123@Mudar.com.br",
                Permissao = new PermissaoDto() { Claims = claim, Nome = "Root" },
                Senha = "123@Mudar",
                Claim = claim,
                Pessoa = new PessoaDto()
                {
                    Nome = "Teste",
                    Celular = "(35)99244-5418",
                    CNPJ = "",
                    CPF = "12345678909",
                    DataNascimento = new DateTime(1990, 01, 31),
                    Email = "123@Mudar.com.br",
                    InscricaoMunicipal = "",
                    NomeFantasia = "",
                    Telefone = "",
                    TipoPessoa = EnumTipoPessoa.Fisica,
                    EnderecoPessoas = new List<EnderecoPessoaDto>()
                    {
                        new EnderecoPessoaDto()
                        {
                            Complemento ="Casa",
                            Endereco = new EnderecoDto()
                            {
                                Bairro ="A",
                                Cep = "37500000",
                                Cidade = "B",
                                Estado = "MG",
                                Pais = "Brazil",
                                Rua = "C"
                            },
                            Latitude = "",
                            Longitude = "",
                            Numero = 2
                        }
                    }
                },
                TipoUsuarioId = Guid.Parse("c81f66d2-16bd-48a6-b93e-20ee7ee41fd9")
            };
            var convert = JsonConvert.SerializeObject(pessoa);

            //Act
            _integrationTesteFixture.Client.DefaultRequestHeaders.Add("privateKey", "MIIEowIBAAKCAQEAxyVBOmPABNg34FKmRxESerhSf7GLjJuupyOflhAZpatuRK3vAON4UqIHS0drci2CgeKlyJxEJEgwf9gKoOhHfwZ0lJAr89me0Ks8ag0exJ7xZBBiPtijfoqChOuxKFvKkKSy+g2jVcmCtWYOxlgh58PdFE098dyKoWC3nwXF/B6IIjWBo7rOnj8xnScXgLve0U8s8L8kwBoq2uXPHFLQH5J3MKZThntdrkLTHHWU5PYajwbXl615rnV8ClPfwIuF9F2ePPyF+ck6vM3vx5sbuMPMKIcq1oBAqianIoFkHcLS2jlXynX5cAobS/c9LQ9Xqv3U1weHUtnG922raD7/8QIDAQABAoIBAQCMsAIL2Qp/oayf2mPD0wjGD8+gjHJ0zEsvotgMMKWdx6Vn+aTecNTBM9yJTxRWHlaToeXS+qqdIy64Mo0XreFMmOflSJD0fapX6pEMruYsq8kHExgFJBEkxX99nfCS/X32f5Q9WUMpyOmBc28+qmaRkGpv/D2lz1NUvLocKvz6pewpGETQBun63Dv8h0ty02qjDr3Pun8R+Ox7fxITm6chHXwAJ1vYgk4uhNE0YBVoKOWju5ZmHQCxjT1Ns463yyf3GRRoFcn7oG995S9/E9xvc2zWgkECt7XDi3ax51QSQDjhg7avhHL+IbB52zGYZzOR+6F/gIolKBgiEEsRbx09AoGBAOK2GLLH1NE/7ZqNvlHKOfp7FVIbSc5gHb/pI6hpgnAy5k95cHnlTEnETXPpiG+y3U28v32xJOOEiZzv32lutHhv68ZyKiwH6rmS5i15TZa7eTPNESp6JKlh8lTvg+0948HHC8mJUYPvY+NwclXxxYFYFkmpIDz7U284oaiScz9zAoGBAODffVVI/heARGz71BtVRpq+u5bG4ag0pcbpF0mtsJgIByfEdkhkkMr6aeLmU+LQvFXInL6eMoNtcJMvyw3K06z9yjsuHB33aDz5jbZqncNXYt34orr6xIAzkV85YFP1ncr4fYka/VpmfIvT3lNkWwF5KnvlSYrFTT2E4YOCKiILAoGAcH/eJ7FD6QYpGN2niJyqQqKbROAnstI9UQMW37ZjtNt9MAjaCJMBVUWlDZTgUFVYvf+gonWqEYCubQMXQRFfWrhnLlVumeTf1HCR6hTcrKShE1R6ZTKxSKBDCWTFeY+RmpH0RnDu02KSlcUx53YPBQ06Ghlj1v78Ox/GEImDyQMCgYBplSWwzIPZHvWBwj/V0ZVEBPfpFFpRct6/ZSP1CSNYTrSlXF45IVbGpwreaUzLuzwifv3xli+be+AWi6MoR6pZmBPC86RqAYck0ftSwf5vAHHATQSDDEkE9LF152euJC3BZijzHgQE1Qf3UzQZLY55Q53J7F86U+cvUlvcNlp3/wKBgF7qaOjNcbz1Y5AIDIGm3kSgkqsXf2OU03qxAMt2nA/hPeRQf2I4Q0DaGP406tV3Z4/PLUE+dsV/Y33cvTp0Id83cLiA1X4uwFufEa8EN0vdpaiT13nSomh5rh5fflOcJ9JvBET9rZ5Cn4BTkm2zp4BAfqU+veAXunDInJLTecFA");
            var post = await _integrationTesteFixture.Client.PostAsJsonAsync("api/Usuario/Registrar", pessoa);

            //Assert
            post.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Cadastro de Usuario Com erro")]
        [Trait("Usuario", "Integração Usuario")]
        public async Task Usuario_RealizaCadastro_DeveExecutarComErro()
        {
            //Arrange
            var claim = new List<ClaimDto>()
                {
                    new ClaimDto() { Nome = "Usuario", Valor = "All" },
                    new ClaimDto() { Nome = "Compra", Valor = "All" },
                    new ClaimDto() { Nome = "Produto", Valor = "All" },
                    new ClaimDto() { Nome = "Email", Valor = "All" }
                };
            var pessoa = new RegistroUsuarioDto()
            {

                ConfirmacaoSenha = "123@Mudar",
                Email = "123@Mudar.com.br",
                Permissao = new PermissaoDto() { Claims = claim, Nome = "Root" },
                Senha = "123@Mudar",
                Claim = claim,
                Pessoa = new PessoaDto()
                {
                    Nome = "Teste",
                    Celular = "(35)99244-5418",
                    CNPJ = "",
                    CPF = "12345678909",
                    DataNascimento = new DateTime(1990, 01, 31),
                    Email = "123@Mudar.com.br",
                    InscricaoMunicipal = "",
                    NomeFantasia = "",
                    Telefone = "",
                    TipoPessoa = EnumTipoPessoa.Fisica,
                    EnderecoPessoas = new List<EnderecoPessoaDto>()
                    {
                        new EnderecoPessoaDto()
                        {
                            Complemento ="Casa",
                            Endereco = new EnderecoDto()
                            {
                                Bairro ="A",
                                Cep = "37500000",
                                Cidade = "B",
                                Estado = "MG",
                                Pais = "Brazil",
                                Rua = "C"
                            },
                            Latitude = "",
                            Longitude = "",
                            Numero = 2
                        }
                    }
                }
            };


            //Act
            var post = await _integrationTesteFixture.Client.PostAsJsonAsync("api/Usuario/Registrar", pessoa);

            //Assert
            Assert.True(post.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
    }
}
///
/// Para teste
/// MIIEowIBAAKCAQEAxyVBOmPABNg34FKmRxESerhSf7GLjJuupyOflhAZpatuRK3vAON4UqIHS0drci2CgeKlyJxEJEgwf9gKoOhHfwZ0lJAr89me0Ks8ag0exJ7xZBBiPtijfoqChOuxKFvKkKSy+g2jVcmCtWYOxlgh58PdFE098dyKoWC3nwXF/B6IIjWBo7rOnj8xnScXgLve0U8s8L8kwBoq2uXPHFLQH5J3MKZThntdrkLTHHWU5PYajwbXl615rnV8ClPfwIuF9F2ePPyF+ck6vM3vx5sbuMPMKIcq1oBAqianIoFkHcLS2jlXynX5cAobS/c9LQ9Xqv3U1weHUtnG922raD7/8QIDAQABAoIBAQCMsAIL2Qp/oayf2mPD0wjGD8+gjHJ0zEsvotgMMKWdx6Vn+aTecNTBM9yJTxRWHlaToeXS+qqdIy64Mo0XreFMmOflSJD0fapX6pEMruYsq8kHExgFJBEkxX99nfCS/X32f5Q9WUMpyOmBc28+qmaRkGpv/D2lz1NUvLocKvz6pewpGETQBun63Dv8h0ty02qjDr3Pun8R+Ox7fxITm6chHXwAJ1vYgk4uhNE0YBVoKOWju5ZmHQCxjT1Ns463yyf3GRRoFcn7oG995S9/E9xvc2zWgkECt7XDi3ax51QSQDjhg7avhHL+IbB52zGYZzOR+6F/gIolKBgiEEsRbx09AoGBAOK2GLLH1NE/7ZqNvlHKOfp7FVIbSc5gHb/pI6hpgnAy5k95cHnlTEnETXPpiG+y3U28v32xJOOEiZzv32lutHhv68ZyKiwH6rmS5i15TZa7eTPNESp6JKlh8lTvg+0948HHC8mJUYPvY+NwclXxxYFYFkmpIDz7U284oaiScz9zAoGBAODffVVI/heARGz71BtVRpq+u5bG4ag0pcbpF0mtsJgIByfEdkhkkMr6aeLmU+LQvFXInL6eMoNtcJMvyw3K06z9yjsuHB33aDz5jbZqncNXYt34orr6xIAzkV85YFP1ncr4fYka/VpmfIvT3lNkWwF5KnvlSYrFTT2E4YOCKiILAoGAcH/eJ7FD6QYpGN2niJyqQqKbROAnstI9UQMW37ZjtNt9MAjaCJMBVUWlDZTgUFVYvf+gonWqEYCubQMXQRFfWrhnLlVumeTf1HCR6hTcrKShE1R6ZTKxSKBDCWTFeY+RmpH0RnDu02KSlcUx53YPBQ06Ghlj1v78Ox/GEImDyQMCgYBplSWwzIPZHvWBwj/V0ZVEBPfpFFpRct6/ZSP1CSNYTrSlXF45IVbGpwreaUzLuzwifv3xli+be+AWi6MoR6pZmBPC86RqAYck0ftSwf5vAHHATQSDDEkE9LF152euJC3BZijzHgQE1Qf3UzQZLY55Q53J7F86U+cvUlvcNlp3/wKBgF7qaOjNcbz1Y5AIDIGm3kSgkqsXf2OU03qxAMt2nA/hPeRQf2I4Q0DaGP406tV3Z4/PLUE+dsV/Y33cvTp0Id83cLiA1X4uwFufEa8EN0vdpaiT13nSomh5rh5fflOcJ9JvBET9rZ5Cn4BTkm2zp4BAfqU+veAXunDInJLTecFA