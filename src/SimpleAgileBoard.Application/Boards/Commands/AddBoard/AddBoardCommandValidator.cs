using System.Data;
using FluentValidation;

namespace SimpleAgileBoard.Application.Boards.Commands.AddBoard
{
    public class AddBoardCommandValidator : AbstractValidator<AddBoardCommand>
    {
        public AddBoardCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NotePrefix).NotNull().NotEmpty();
        }
    }
}