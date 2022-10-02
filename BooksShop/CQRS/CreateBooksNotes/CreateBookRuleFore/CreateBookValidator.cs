using Domain.Новая_папка;
using FluentValidation;

namespace BooksShop.CQRS.CreateBooksNotes.CreateBookRuleFore
{
    public class CreateBookValidator : AbstractValidator<Book>
    {
        public CreateBookValidator()
        {
            RuleFor(a => a.name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(120);

            RuleFor(a => a.name_books)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(120);

            RuleFor(a => a.year)
                .NotNull();
        }
    }
}
