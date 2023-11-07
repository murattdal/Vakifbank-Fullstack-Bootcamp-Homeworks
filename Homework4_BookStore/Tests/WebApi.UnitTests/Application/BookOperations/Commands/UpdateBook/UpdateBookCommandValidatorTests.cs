using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        // Invalid data for Title
        [InlineData("L", 111, 1, 2)]
        // Invalid data for PageCount
        [InlineData("Dune", -1, 1, 2)]
        // Invalid data for GenreId
        [InlineData("Dune", 111, -1, 2)]
        [InlineData("Dune", 111, 10, 2)]
        // Invalid data for AuthorId
        [InlineData("Dune", 111, 1, -1)]
        [InlineData("Dune", 111, 1, 10)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            // ARRANGE
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Id = 2;
            command.Model = new UpdateBookModel
            {
                 Title = title,
                 PageCount = pageCount,
                 PublishDate = new DateTime(1920, 10, 15),
                 GenreId = genreId,
                 AuthorId = authorId
            };
            // ACT
            var result = validator.Validate(command);
            // ASSERT
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidDateTimeIsGiven_Validator_ShouldBeReturnErrors()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Id = 2;
            command.Model = new UpdateBookModel
            {
                Title = "Dune",
                GenreId = 2,
                AuthorId = 3,
                PageCount = 111,
                PublishDate = DateTime.Now.AddYears(1)
            };
            // When
            var result = validator.Validate(command);
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(null, default, default, default)]
        // Invalid data for Title
        [InlineData(null, 111, 1, 2)]
        [InlineData(default, 111, 1, 2)]
        [InlineData("", 111, 1, 2)]
        // Invalid data for PageCount
        [InlineData("Dune", default, 1, 2)]
        // Invalid data for GenreId
        [InlineData("Dune", 111, default, 2)]
        // Invalid data for AuthorId
        [InlineData("Dune", 111, 1, default)]
        public void WhenNullOrEmptyInputsAreGiven_Validator_ShouldNotBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            // ARRANGE
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Id = 2;
            command.Model = new UpdateBookModel
            {
                 Title = title,
                 PageCount = pageCount,
                 PublishDate = new DateTime(1920, 10, 15),
                 GenreId = genreId,
                 AuthorId = authorId
            };
            // ACT
            var result = validator.Validate(command);
            // ASSERT
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void WhenModelNotGiven_Validator_ShouldBeReturnErrors()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Id = 2;
            // When
            var result = validator.Validate(command);
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenIdNotGiven_Validator_ShouldBeReturnErrors()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Model = new UpdateBookModel
            {
                Title = "Dune",
                GenreId = 2,
                AuthorId = 3,
                PageCount = 111,
                PublishDate = new DateTime(1920, 08, 26)
            };
            // When
            var result = validator.Validate(command);
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}