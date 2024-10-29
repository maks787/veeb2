using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private static Kasutaja _kasutaja = new Kasutaja(1, "kasutajanimi", "1234", "Eesnimi", "Perenimi");



        // GET: kasutaja
        [HttpGet]
        public ActionResult<Kasutaja> GetKasutaja()
        {
            return Ok(_kasutaja); 
        }

        // PUT: kasutaja/muuda-nime
        [HttpPut("muuda-nime")]
        public ActionResult<Kasutaja> MuudaNime([FromBody] string uusNimi)
        {
            if (string.IsNullOrEmpty(uusNimi))
            {
                return BadRequest("Uus nimi ei saa olla tühi."); 
            }

            _kasutaja.Kasutajanimi = uusNimi; 
            return Ok(_kasutaja); 
        }

        // PUT: kasutaja/muuda-parooli
        [HttpPut("muuda-parooli")]
        public ActionResult<Kasutaja> MuudaParooli([FromBody] string uusParool)
        {
            if (string.IsNullOrEmpty(uusParool))
            {
                return BadRequest("Uus parool ei saa olla tühi."); 
            }

            _kasutaja.Parool = uusParool; 
            return Ok(_kasutaja); 
        }

        // PUT: kasutaja/muuda-eesnime
        [HttpPut("muuda-eesnime")]
        public ActionResult<Kasutaja> MuudaEesnime([FromBody] string uusEesnimi)
        {
            if (string.IsNullOrEmpty(uusEesnimi))
            {
                return BadRequest("Uus eesnimi ei saa olla tühi."); 
            }

            _kasutaja.Eesnimi = uusEesnimi; 
            return Ok(_kasutaja); 
        }

        // PUT: kasutaja/muuda-perenime
        [HttpPut("muuda-perenime")]
        public ActionResult<Kasutaja> MuudaPerenime([FromBody] string uusPerenimi)
        {
            if (string.IsNullOrEmpty(uusPerenimi))
            {
                return BadRequest("Uus perenimi ei saa olla tühi."); 
            }

            _kasutaja.Perenimi = uusPerenimi; 
            return Ok(_kasutaja); 
        }
    }
}
