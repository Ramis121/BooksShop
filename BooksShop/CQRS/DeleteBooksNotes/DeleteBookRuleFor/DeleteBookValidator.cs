using Domain.Новая_папка;
using FluentValidation;

namespace BooksShop.CQRS.DeleteBooksNotes.DeleteBookRuleFor
{
    public class DeleteBookValidator : AbstractValidator<Book>
    {
        public DeleteBookValidator()
        {
            RuleFor(a => a.Id)
                .NotNull();
        }
    }

}
