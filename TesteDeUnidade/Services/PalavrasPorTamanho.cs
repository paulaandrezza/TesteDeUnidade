namespace TesteDeUnidade.Services
{
    public class PalavrasPorTamanho
    {
        // Receber uma lista de palavras e retornar as que tem 10 ou mais caracteres.
        public List<string> SelecionarPalavras(IEnumerable<string> palavras)
        {
            List<string> result = new List<string>();

            foreach (string palavra in palavras)
                if (palavra.Length >= 10)
                    result.Add(palavra);

            return result;
        }
    }
}
