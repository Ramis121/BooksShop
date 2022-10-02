using Domain.Новая_папка;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksShop.Interface
{
    public interface IGenericBooks<T> where T : class
    {
        Task<string> GetBookId(int id);
        Task<IEnumerable<T>> GetBooks();
        Task<T> AddBooks(Book book);
        Task<T> UpdateBooks(Book book);
        Task<int> DeleteBooks(int id);
        void Insert(T book);
        IEnumerable<Book> GetBook();
    }
}
