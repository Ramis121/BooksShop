using BooksShop.Data;
using BooksShop.Exeprions;
using BooksShop.Interface;
using Domain.Новая_папка;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksShop.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly ApplicationDbContext dbContext;
        public readonly ILogger<BookRepository> _logger;
        private const string ThisName = nameof(BookRepository);
        public BookRepository(ApplicationDbContext dbContext,
            ILogger<BookRepository> logger)
        {
            this.dbContext = dbContext;
            this._logger = logger;
        }
        public async Task<string> GetBookId(int id)
        {
            var loggetid = $"{ThisName}/{nameof(GetBookId)}";
            _logger.LogInformation($"The {loggetid} method has run");
            var result_getid = await dbContext.books.FindAsync(id);
            Book book = null;
            if (!string.IsNullOrEmpty(result_getid.Id.ToString()))
            {
                _logger.LogInformation($"{loggetid} get book id has book id: {result_getid.Id}, finding");
                book = await dbContext.books.FindAsync(result_getid.Id);
                if (book is not null)
                {
                    _logger.LogInformation($"{loggetid}checking existing getbooksId: {result_getid.Id}");
                }
            }
            return result_getid.name;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var loggetbook = $"{ThisName}/{nameof(GetBooks)}";
            try
            {
                return await dbContext.books
                    .OrderBy(a => a.Id)
                    .ToListAsync();
            }
            catch
            {
                throw new ApiExeptions($"{loggetbook} list is books not foold");
            }
        }

        public async Task<Book> AddBooks(Book book)
        {
            var logAdd = $"{ThisName}/{nameof(AddBooks)}";
            _logger.LogInformation($"add method starts working {logAdd}");
            if (book is null)
            {
                _logger.LogError("the cell with books is empty ");
                return null;
            }
            if (string.IsNullOrWhiteSpace(book.name_books) && string.IsNullOrWhiteSpace(book.name))
            {
                _logger.LogError($"books with spaces are not scanned {logAdd}");
                return null;
            }
            if (dbContext.books.Any(a => a.Id == book.Id))
            {
                _logger.LogError($"index is the same {book.Id} method {logAdd}");
                return null;
            }

            try
            {
                Insert(new Book
                {
                    CreateDate = DateTime.UtcNow,
                    Id = book.Id,
                    name = book.name,
                    name_books = book.name_books,
                    year = book.year
                });
                _logger.LogInformation($"new book added {book.name_books}");
            }
            catch
            {
                throw new ApiExeptions($"new non book added {book.name_books}");
            }
            return book;
        }

        public async Task<Book> UpdateBooks(Book book)
        {
            var logupdatebook = $"{ThisName}/{nameof(UpdateBooks)}";
            if(book.name is null && book.name_books is null)
            {
                _logger.LogInformation($"{logupdatebook}/ book and authot not foult");
                return null;
            }
            if (string.IsNullOrWhiteSpace(book.name_books) && string.IsNullOrWhiteSpace(book.name))
            {
                _logger.LogInformation($"{logupdatebook}/ book and authot not foult (пусто)");
                return null;
            }
            dbContext.books.Update(book);
            await dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<int> DeleteBooks(int id)
        {
            var logdeletebooks = $"{ThisName}/{nameof(DeleteBooks)}";
            var res = await dbContext.books.FindAsync(id);
            if (res is not null)
            {
                dbContext.books.Remove(res);
                await dbContext.SaveChangesAsync();
                return id;
            }
            _logger.LogError($"{logdeletebooks} {res} is null");

            _logger.LogError($"{logdeletebooks} {id} is null");
            return id;
        }

        public void Insert(Book book)
        {
            var logInsert = $"{ThisName}/{nameof(Insert)}";
            try
            {
                dbContext.books.AddAsync(book);
                dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ApiExeptions($"Error {logInsert}");
            }
        }

        public IEnumerable<Book> GetBook()
        {
            var res = from a in dbContext.books
                      select a.name;

            return (IEnumerable<Book>)res;
        }
    }
}
