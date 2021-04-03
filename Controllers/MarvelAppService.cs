using DesafioPG.Models;
using DesafioPG.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPG.Controllers
{
    [ApiController]
    [Route("marvel")]
    public class MarvelAppService : ControllerBase, IMarvelAppService
    {
        [HttpGet]
        [Route("getpersonagens")]
        public Marvel GetPersonagens()
        {
            var marvelwrapper = new MarvelWrapper();
            var marvel = marvelwrapper.ConsultarPersonagens();
            marvelwrapper.EscreverArquivo(marvel);
            return marvel;
        }
    }
}
