using BooksShop.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BooksShop.CQRS.DeleteBooksNotes.DeleteBookHandler
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int id { get; set; }
    }

    public class DeleteBookHandle : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBookRepository _repository;
        public DeleteBookHandle(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteBooks(request.id);
            return request.id; 
        }
    }
}
