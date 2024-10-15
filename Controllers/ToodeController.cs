using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price += 1;
            return _toode;
        }

        // GET: toode/muuda-aktiivsust
        [HttpGet("muuda-aktiivsust")]
        public Toode MuudaAktiivsust()
        {
            _toode.IsActive = !_toode.IsActive;
            return _toode;
        }

        // GET: toode/muuda-nime/{name}
        [HttpGet("muuda-nime/{name}")]
        public Toode MuudaNime(string name)
        {
            _toode.Name = name;
            return _toode;
        }

        // GET: toode/korruta-hinda/{multiplier}
        [HttpGet("korruta-hinda/{multiplier}")]
        public Toode KorrutaHinda(double multiplier)
        {
            _toode.Price *= multiplier;
            return _toode;
        }
    }
}
