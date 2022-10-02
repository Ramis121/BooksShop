using BooksShop.Interface;
using Domain.Новая_папка;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BooksShop.CQRS.CreateBooksNotes.CreateBookHandler
{
    public class CreateBookCommands : IRequest<Book>
    {
        public int book_id { get; set; }
        public string bookName { get; set; }
        public int book_year { get; set; }
        public string name_author { get; set; }
        public DateTime createbook { get; set; }
    }

    public class GetBookHandlers : IRequestHandler<CreateBookCommands, Book>
    {
        private readonly IBookRepository _repository;
        private const string ThisName = nameof(GetBookHandlers);
        public GetBookHandlers(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> Handle(CreateBookCommands request, CancellationToken cancellationToken)
        {
            var logaddbooks = $"{ThisName}/{nameof(Handle)}";
            
            var res = new Book
            {
                name = request.name_author,
                name_books = request.bookName,
                Id = request.book_id,
                year = request.book_year,
                CreateDate = request.createbook
            };
            return await _repository.AddBooks(res);
        }
    }
}
