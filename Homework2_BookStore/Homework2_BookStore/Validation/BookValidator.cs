using FluentValidation;

namespace Homework2_BookStore.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title field is required.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id field is required.");

            RuleFor(x => x.PageCount)
                .GreaterThan(0)
                .WithMessage("PageCount must be greater than zero.");

            RuleFor(x => x.GenreId)
                .NotEmpty()
                .WithMessage("GenreId field is required.");
        }

    }
}
