using TesteDeUnidade.Services;

namespace TestProject1.Services
{
    public class PalavrasPorTamanhoTest
    {
        [Fact]
        public void Nao_deve_retornar_palavras_com_menos_de_dez_caracteres()
        {
            // Arrange
            var palavrasPorTamanho = new PalavrasPorTamanho();
            var palavrasASerFiltrada = "Quimérica";
            var listaSemPalavrasValidas = new[] { palavrasASerFiltrada };

            // Act
            var result = palavrasPorTamanho.SelecionarPalavras(listaSemPalavrasValidas);

            //Assert
            Assert.True(result.Count == 0);
            Assert.All(result, palavra => { Assert.True(palavra.Length >= 10); });
        }

        [Fact]
        public void Deve_retornar_palavras_com_mais_de_dez_caracteres()
        {
            var palavrasPorTamanho = new PalavrasPorTamanho();

            var result = palavrasPorTamanho.SelecionarPalavras(
                new[] {
                    "Idiossincrasia",
                    "Quimérica"
                }
            );

            Assert.True(result.Count == 1);
            Assert.Contains(result, x => x == "Idiossincrasia");
        }

        [Fact]
        public void Deve_retornar_palavras_com_dez_caracteres()
        {
            // Arrange
            var palavrasPorTamanho = new PalavrasPorTamanho();
            var palavrasASerFiltrada = "Obnubilado";
            var listaSemPalavrasValidas = new[] { palavrasASerFiltrada };

            // Act
            var result = palavrasPorTamanho.SelecionarPalavras(listaSemPalavrasValidas);

            //Assert
            Assert.True(result.Count == 1);
            Assert.Contains(result, x => x == palavrasASerFiltrada);
        }

        [Theory]
        //[InlineData("Quimérica", false)]
        //[InlineData("Idiossincrasia", true)]
        [MemberData(nameof(CasosDeTeste))]
        public void validar_lista_conhecida(string palavra, bool deveAparecer)
        {
            // Arrange
            var palavrasPorTamanho = new PalavrasPorTamanho();
            var listaPalavras = new[] { palavra };

            // Act
            var result = palavrasPorTamanho.SelecionarPalavras(listaPalavras);

            //Assert
            Assert.Equal(result.Contains(palavra), deveAparecer);
        }

        public static IEnumerable<object[]> CasosDeTeste()
        {
            return new[] {
                new object[] { "Quimérica", false },
                new object[] { "Idiossincrasia", true }
            };
        }


        [Fact]
        public void Nao_deve_retornar_palavras_com_menos_de_dez_caracteres2()
        {
            var palavrasPorTamanho = new PalavrasPorTamanho();

            var result = palavrasPorTamanho.SelecionarPalavras(
                new[] {
                    "Idiossincrasia",
                    "Ambivalente",
                    "Quimérica",
                    "Perpendicular",
                    "Efêmero",
                    "Pletora",
                    "Obnubilado",
                    "Xilografia",
                    "Quixote",
                    "Inefável"
                }
            );

            var expected_result = new[] {
                "Idiossincrasia",
                "Ambivalente",
                "Perpendicular",
                "Obnubilado",
                "Xilografia"
            };

            Assert.Equal(expected_result, result);
        }
    }
}