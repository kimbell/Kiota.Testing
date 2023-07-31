using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Bob.Kiota.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets weather
        /// </summary>
        /// <returns></returns>
        [HttpGet("weather", Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Gets animals
        /// </summary>
        /// <param name="correlationId"></param>
        /// <returns></returns>
        [HttpGet("animals", Name = "GetAnimals")]
        [ProducesResponseType(typeof(IEnumerable<Animal>), 200)]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<Animal> GetAnimals([FromHeader] string? correlationId = null)
        {
            return new Animal[]
            {
                new Dog
                {
                    Name = "Fido",
                    Something = 4
                },
                new Cat
                {
                    Name = "Whiskers",
                    Lives = 9
                }
            };
        }

        [HttpGet("echo-animals", Name = "EchoGetAnimals")]
        [ProducesResponseType(typeof(IEnumerable<Animal>), 200)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IEnumerable<Animal> EchoAnimals([FromBody] IEnumerable<Animal> animals) => animals;
    }

    [JsonDerivedType(typeof(Dog), "d")]
    [JsonDerivedType(typeof(Cat), "c")]
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "bob")]
    public class Animal
    {
        public required string Name { get; set; }
        public ChipStatus ChipStatus { get; set; }
    }
    public class Dog: Animal
    {
        public int Something { get; set; }
    }

    public class Cat : Animal
    {
        public int Lives { get; set; }
    }

    public enum ChipStatus
    {
        NotChipped,
        Chipped
    }
}