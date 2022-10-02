using BooksShop.Interface;
using Domain.Новая_папка;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BooksShop.CQRS.GetBooksNotes.GetBooksHandler
{
    public class CreateBookCommands : IRequest<IEnumerable<Book>>
    {
        public int book_id { get; set; }    
        public string bookName { get; set; }
        public string nameAuthor { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class CreateBookHandler : IRequestHandler<CreateBookCommands, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Handle(CreateBookCommands request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooks();
        }
    }
}
