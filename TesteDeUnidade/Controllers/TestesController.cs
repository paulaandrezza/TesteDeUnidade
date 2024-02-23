using Microsoft.AspNetCore.Mvc;
using TesteDeUnidade.Services;

namespace TesteDeUnidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestesController : ControllerBase
    {
        private readonly ILogger<TestesController> _logger;

        public TestesController(ILogger<TestesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<IEnumerable<WeatherForecast>> PostListaPalavras([FromBody] string[] palavras)
        {
            var palavrasPorTamanho = new PalavrasPorTamanho();

            var result = palavrasPorTamanho.SelecionarPalavras(palavras);

            return Ok(result);
        }
    }
}
