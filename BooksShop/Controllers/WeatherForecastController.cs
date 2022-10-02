using BooksShop.Interface;
using Domain.Новая_папка;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BooksShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBookRepository book;
        private readonly Mediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBookRepository book, Mediator mediator)
        {
            _logger = logger;
            this.book = book ??
                throw new ArgumentException(nameof(book));
            _mediator = mediator
                ?? throw new ArgumentException(nameof(mediator));
        }

        [HttpGet]
        public string Get()
        {
            List<string> books = new List<string>(); 
            books.Add("asdsad");
            books.Add("asdsad");
            books.Add("asdsad");
            books.Add("asdsad");

            var res = string.Join(',', books);
            return res;
        }

        [HttpGet("getaction")]
        public IActionResult GetAction()
        {
            return Ok(_mediator.Send(book.GetBook()));
        }
    }
}
