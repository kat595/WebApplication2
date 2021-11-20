using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastServices _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get_default();
            return result;
        }

        [HttpGet("currentDay/{max}")] // do tej metody odnosimy siê przez /currentDay, alternatywnie [Route("currentDay")]
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get_default();
            return result;
        }

        [HttpPost] // akcja Post
        public ActionResult<string> Hello([FromBody]string name)
        {
            //HttpContext.Response.StatusCode = 401;
            return StatusCode(401, $"Hello {name}"); // w zaleznosci od akcji mozemy przekazac rozne kody zapytañ
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery]int count, [FromBody]TemperatureRequest request)
        {
            if (count < 0 || request.Min > request.Max)
            {
                return BadRequest();
            }

            var result = _service.Get(count, request.Min, request.Max);
            return Ok(result);

        }
    }
}