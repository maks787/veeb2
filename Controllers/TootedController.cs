using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET https://localhost:4444/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }
        [HttpGet("{index}")]
        public ActionResult<Toode> GetProductByIndex(int index)
        {
            if (index < 0 || index >= _tooted.Count)
            {
                return NotFound("Toode määratud indeksiga ei leitud.");
            }

            return _tooted[index];
        }
        [HttpGet("korgeim-hind")]
        public ActionResult<Toode> SuuremHind()
        {
            if (!_tooted.Any())
            {
                return NotFound("Tooted ei ole saadaval.");
            }

            var suuremhind = _tooted.OrderByDescending(toode => toode.Price).FirstOrDefault();
            return suuremhind;
        }

        // DELETE https://localhost:4444/tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }
        [HttpDelete("kustuta-koik")]
        public ActionResult DeleteAll()
        {
            _tooted.Clear();
            return Ok("Kõik tooted on kustutatud.");
        }

        // POST https://localhost:4444/tooted/lisa/1/Coca/1.5/true
        [HttpPost("lisa")]
        public ActionResult<List<Toode>> Add([FromBody] Toode uusToode)
        {
            _tooted.Add(uusToode);
            return Ok(_tooted); // Возвращаем обновленный список
        }


        [HttpPost("lisa2")]
        public List<Toode> Add2(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        // PATCH https://localhost:4444/tooted/hind-dollaritesse/1.5
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public List<Toode> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }
        [HttpPut("muuda-koik-vaara")]
        public ActionResult VahetaTrue()
        {
            foreach (var toode in _tooted)
            {
                toode.IsActive = false;
            }
            return Ok("Kõik toodete aktiivsus on nüüd väära.");
        }
        private static Random _random = new Random();

        // GET: /tooted/juhuslik/{min}/{max}
        [HttpGet("juhuslik/{min}/{max}")]
        public ActionResult<int> GetRandomNumber(int min, int max)
        {
            if (min > max)
            {
                return BadRequest("Min peaks olema väiksem või võrdne Max.");
            }

            int randomNumber = _random.Next(min, max + 1);
            return randomNumber;
        }

        // GET: /tooted/synniaasta/{year}
        [HttpGet("synniaasta/{year}")]
        public ActionResult<string> CalculateAge(int year)
        {
            int currentYear = DateTime.Now.Year;
            int age1 = currentYear - year;
            int age2 = age1 - 1;

            if (year > currentYear || year <= 0)
            {
                return BadRequest("Palun sisesta kehtiv sünniaasta.");
            }

            bool hasHadBirthdayThisYear = DateTime.Now.DayOfYear >= new DateTime(currentYear, 1, 1).DayOfYear;
            int actualAge = hasHadBirthdayThisYear ? age1 : age2;

            string response = $"Oled {actualAge} aastat vana.";
            return response;
        }
    }
}