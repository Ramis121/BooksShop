using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MediatR;
using Domain.Новая_папка;
using System.Threading.Tasks;
using BooksShop.CQRS.GetBooksNotes.GetBooksHandler;
using BooksShop.CQRS.CreateBooksNotes.CreateBookHandler;
using BooksShop.CQRS.DeleteBooksNotes.DeleteBookHandler;
using BooksShop.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository repository;
        public ValuesController(IMediator mediator, IBookRepository repository)
        {
            _mediator = mediator;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetList()
        {
            return base.Ok(await _mediator.Send(new CQRS.GetBooksNotes.GetBooksHandler.CreateBookCommands()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            return Ok(await repository.GetBookId(id));
        }

        [HttpPost]
        public Task<Book> Post([FromBody] CQRS.CreateBooksNotes.CreateBookHandler.CreateBookCommands getBook)
        {
            return getBook is null ? null : _mediator.Send(getBook);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_mediator.Send(new DeleteBookCommand { id = id }));
        }
    }
}
