using Domain.Новая_папка;
using FluentValidation;

namespace BooksShop.CQRS.GetBooksNotes.GetBooksRuleFore
{
    public class GetBooksValidator : AbstractValidator<Book>
    {
        public GetBooksValidator()
        {
            RuleFor(a => a.name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(120);

            RuleFor(b => b.name_books)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(120);

            RuleFor(a => a.CreateDate)
                .NotEmpty();
        }
    }
}
